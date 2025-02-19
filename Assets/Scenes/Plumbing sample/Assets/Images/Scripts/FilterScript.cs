using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FilterScript : MonoBehaviour
{     
    public Animator firstAnimator;
    public string firstAnimation = "FirstAnim";
    public GameObject secondObject;    
    public Animator secondAnimator;
    public string secondAnimation = "SecondAnim";
    public GameObject objectToActivate;

    public Collider objectCollider;
    public HintRemove hintr;
    public Button hintbtn;

    void Start()
    {

        if (secondObject)
        {
            secondAnimator = secondObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                hintr.hintdis();
                hintbtn.interactable = false;
                StartCoroutine(PlayAnimations());
            }
        }
    }

    IEnumerator PlayAnimations()
    {
        if (firstAnimator)
        {
            objectCollider.enabled = false;
            firstAnimator.Play(firstAnimation);

            yield return new WaitUntil(() => firstAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0);

            yield return new WaitForSeconds(firstAnimator.GetCurrentAnimatorStateInfo(0).length);
            yield return new WaitForSeconds(1f);
        }

        if (secondAnimator)
        {
            secondAnimator.Play(secondAnimation);

            yield return new WaitUntil(() => secondAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0);
            yield return new WaitForSeconds(secondAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        objectCollider.enabled = true;

        if (objectToActivate) objectToActivate.SetActive(true);
    }
}