using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class FaucetDrag1 : MonoBehaviour
{
    public Transform snapTarget;
    public UnityEvent quiz2;
    private Camera activeCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zDistance;
    public float snapThreshold = 0.2f;
    private Collider objectCollider;
    public GameObject quizenable;
    public HintRemove hintr;

    public GameObject otherGameObject;
    public Button hintBtn;

    public Vector3 minBounds = new Vector3(-5f, 0f, -5f);
    public Vector3 maxBounds = new Vector3(5f, 5f, 5f);

    private bool hintClicked = false;

    void Start()
    {
        activeCamera = Camera.main;
        objectCollider = GetComponent<Collider>();

        if (hintBtn != null)
        {
            hintBtn.onClick.AddListener(OnHintButtonClicked);
        }
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
                if (hintClicked && otherGameObject != null)
                {
                    otherGameObject.SetActive(false);
                }

                isDragging = true;
                zDistance = activeCamera.WorldToScreenPoint(transform.position).z;
                offset = transform.position - GetMouseWorldPosition();
            }
        }
    }

    void DragObjectWithMouse()
    {
        Vector3 localPos = transform.parent.InverseTransformPoint(GetMouseWorldPosition() + offset);

        localPos.x = Mathf.Clamp(localPos.x, minBounds.x, maxBounds.x);
        localPos.y = Mathf.Clamp(localPos.y, minBounds.y, maxBounds.y);
        localPos.z = Mathf.Clamp(localPos.z, minBounds.z, maxBounds.z);

        transform.position = transform.parent.TransformPoint(localPos);
    }

    void TrySnapToTarget()
    {
        if (snapTarget == null) return;

        float distance = Vector3.Distance(transform.position, snapTarget.position);

        if (distance <= snapThreshold)
        {
            transform.position = snapTarget.position;
            objectCollider.enabled = false;
            StartCoroutine(DisableColliderAndInvokeEvent());
        }
    }

    IEnumerator DisableColliderAndInvokeEvent()
    {
        hintr.hintdis();

        yield return new WaitForSeconds(2f);

        quiz2.Invoke();

        Debug.Log("UnityEvent quiz2 invoked.");

        enabled = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        if (activeCamera == null) return Vector3.zero;

        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = zDistance;
        return activeCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    void OnHintButtonClicked()
    {
        hintClicked = true;
        Debug.Log("Hint button clicked.");
    }
}