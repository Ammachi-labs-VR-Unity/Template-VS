using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    public GameObject hint1;
    public Button hintbtn;
    public UnityEvent quiz1;

    private void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == hint1)
                {
                    if (targetObject != null)
                    {
                        hintbtn.enabled = false;
                        targetObject.SetActive(true);
                        Outline script = hint1.GetComponent<Outline>();
                        script.enabled = false;
                        hint1.GetComponent<Collider> ().enabled = false;
                        StartCoroutine(quizdelay());                        

                    }                    
                }
            }
        }
    }
    IEnumerator quizdelay()
    {
        yield return new WaitForSeconds(1.5f);
        quiz1.Invoke();
    }
}