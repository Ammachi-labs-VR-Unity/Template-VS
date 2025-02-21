using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Amrita.AmmachiLabs.Game_Managers.Quiz;

public class SpiritDrag : MonoBehaviour
{
    public Transform snapTarget;
    private Camera activeCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zDistance;
    public float snapThreshold = 0.2f;
    private Collider objectCollider;
    public GameObject markerball;
    public UnityEvent spiritscale;
    public HintRemove hintr;

    public Vector3 minBounds = new Vector3(-5f, 0f, -5f);
    public Vector3 maxBounds = new Vector3(5f, 5f, 5f);


    void Start()
    {
        activeCamera = Camera.main;
        objectCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickObject();
        }

        if (isDragging)
        {
            DragObjectWithMouse();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            TrySnapToTarget();
        }
    }

    void TryPickObject()
    {
        if (activeCamera == null) return;

        Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                zDistance = activeCamera.WorldToScreenPoint(hit.point).z;

                offset = transform.position - activeCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            }
        }
    }

    void DragObjectWithMouse()
    {
        Vector3 newPosition = transform.parent.InverseTransformPoint(GetMouseWorldPosition() + offset);

        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);
        float clampedZ = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);

        transform.position = transform.parent.TransformPoint(new Vector3(clampedX, clampedY, clampedZ));
    }

    void TrySnapToTarget()
    {
        if (snapTarget == null) return;

        float distance = Vector3.Distance(transform.position, snapTarget.position);

        if (distance <= snapThreshold)
        {
            transform.position = snapTarget.position;
            Debug.Log("Object snapped to target. Collider will be disabled in 2 seconds.");
            markerball.SetActive(false);
            StartCoroutine(DisableColliderAndInvokeEvent());
        }
    }

    IEnumerator DisableColliderAndInvokeEvent()
    {
        hintr.hintdis();
        objectCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);

        spiritscale.Invoke();

        enabled = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        if (activeCamera == null) return Vector3.zero;

        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = zDistance;
        return activeCamera.ScreenToWorldPoint(mouseScreenPos);
    }
}