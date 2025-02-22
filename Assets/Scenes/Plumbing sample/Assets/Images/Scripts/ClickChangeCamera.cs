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
    public HintRemove hintr;

    private void Start()
    {
        targetObject.SetActive(false);
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
                        hint1.GetComponent<Collider> ().enabled = false;
                        hintr.hintdis();
                        targetObject.SetActive(true);
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