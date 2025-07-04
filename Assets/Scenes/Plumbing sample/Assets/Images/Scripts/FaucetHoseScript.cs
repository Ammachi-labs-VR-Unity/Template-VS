using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaucetHoseScript : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public HintRemove hintr;
    private int check = 0;
    public Button hintbtn;

    void Start()
    {
        animator = GetComponent<Animator>();
        screwdriverPanel.SetActive(false);
        nextButton.SetActive(false);
    }

    void Update()
    {
        //if(check != 0)
        //{
        //    return; // Prevents multiple clicks from triggering the animation
        //}
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked on valve");
            //check = 1; // Set check to 1 to prevent further clicks until the animation is done
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    hintr.hintdis();
                    animator.Play(animationname);
                    StartCoroutine(WaitForAnimation());
                    hintbtn.interactable = false;
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationname));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        screwdriverPanel.SetActive(true);
        nextButton.SetActive(true);
    }
}