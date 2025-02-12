using UnityEngine;

public class Batterybox_top_lid : MonoBehaviour
{
    public GameObject staticbattery;
    public Animator batteryBoxAnimator;
    public string animstring;
    public GameObject camdis;
    void Start()
    {
        batteryBoxAnimator = GetComponent<Animator>();
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
                    batteryBoxAnimator.Play(animstring);
                    staticbattery.SetActive(true);
                    camdis.SetActive(false);
                }
            }
        }
    }
}
