using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Amrita.AmmachiLabs.Game_Managers.Quiz;

public class SpiritSacale2 : MonoBehaviour
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

    [Header("Movement Constraints")]
    public float minX = -5f, maxX = 5f;
    public float minY = 0f, maxY = 10f;
    public float minZ = -5f, maxZ = 5f;

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
                zDistance = activeCamera.WorldToScreenPoint(transform.position).z;
                offset = transform.position - GetMouseWorldPosition();
            }
        }
    }

    void DragObjectWithMouse()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }

    void TrySnapToTarget()
    {
        if (snapTarget == null) return;

        float distance = Vector3.Distance(transform.position, snapTarget.position);

        if (distance <= snapThreshold)
        {
            Vector3 clampedSnapPosition = snapTarget.position;
            clampedSnapPosition.x = Mathf.Clamp(clampedSnapPosition.x, minX, maxX);
            clampedSnapPosition.y = Mathf.Clamp(clampedSnapPosition.y, minY, maxY);
            clampedSnapPosition.z = Mathf.Clamp(clampedSnapPosition.z, minZ, maxZ);

            transform.position = clampedSnapPosition;

            Debug.Log("Object snapped to target. Collider will be disabled in 2 seconds.");
            markerball.SetActive(false);
            StartCoroutine(DisableColliderAndInvokeEvent());
        }
    }

    IEnumerator DisableColliderAndInvokeEvent()
    {
        yield return new WaitForSeconds(0.5f);

        if (objectCollider != null)
        {
            objectCollider.enabled = false;
            Debug.Log("Collider disabled.");
        }

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