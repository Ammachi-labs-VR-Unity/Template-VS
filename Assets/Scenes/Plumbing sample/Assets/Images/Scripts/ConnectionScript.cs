using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConnectionScript : MonoBehaviour
{
    public GameObject wrench;
    public Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public HintRemove hintr;
    public Button hintbtn;

    void Start()
    {
        screwdriverPanel.SetActive(false);
        nextButton.SetActive(false);
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
                    hintbtn.interactable = false;
                    wrench.SetActive(true);
                    animator.Play(animationname);
                    StartCoroutine(WaitForAnimation());
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