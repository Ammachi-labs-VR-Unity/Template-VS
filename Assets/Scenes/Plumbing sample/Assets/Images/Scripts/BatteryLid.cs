using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BatteryLid : MonoBehaviour
{
    public GameObject activateObject;
    public GameObject deactivateObject;
    public GameObject cameraObject;
    public HintRemove hintr;

    private void Start()
    {
        activateObject.SetActive(false);
        cameraObject.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    hintr.hintdis();
                   activateObject.SetActive(true);
                   deactivateObject.SetActive(false);
                   cameraObject.SetActive(true);
                }
            }
        }
    }
}