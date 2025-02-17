using UnityEngine;
using Cinemachine;

public class ClothDrag : MonoBehaviour
{
    private Camera activeCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zDistance;

    [Header("Movement Constraints")]
    public float minX = -5f, maxX = 5f;
    public float minY = 0f, maxY = 10f;
    public float minZ = -5f, maxZ = 5f;

    void Start()
    {
        activeCamera = Camera.main;

        if (activeCamera == null)
        {
            Debug.LogError("No Camera component found on the Virtual Camera! Make sure the main camera follows Cinemachine.");
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

    Vector3 GetMouseWorldPosition()
    {
        if (activeCamera == null) return Vector3.zero;

        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = zDistance;
        return activeCamera.ScreenToWorldPoint(mouseScreenPos);
    }
}