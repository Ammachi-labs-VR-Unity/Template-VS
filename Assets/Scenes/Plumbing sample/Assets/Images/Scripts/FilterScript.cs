using UnityEngine;
using System.Collections;

public class FilterScript : MonoBehaviour
{
    public string firstAnimation = "FirstAnim";
    public GameObject secondObject;
    public string secondAnimation = "SecondAnim";
    public GameObject objectToActivate;

    private Animator firstAnimator;
    public Collider objectCollider;
    private Animator secondAnimator;

    void Start()
    {
        firstAnimator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider>();

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

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    StartCoroutine(PlayAnimations());
                }
            }
        }
    }

    IEnumerator PlayAnimations()
    {
        if (firstAnimator)
        {
            if (objectCollider) objectCollider.enabled = false;

            firstAnimator.Play(firstAnimation);

            yield return new WaitForSeconds(firstAnimator.GetCurrentAnimatorStateInfo(0).length);

            yield return new WaitForSeconds(1f);
        }

        if (secondAnimator)
        {
            secondAnimator.Play(secondAnimation);

            yield return new WaitForSeconds(secondAnimator.GetCurrentAnimatorStateInfo(0).length);
        }

        if (objectCollider) objectCollider.enabled = true;

        if (objectToActivate) objectToActivate.SetActive(true);
    }
}