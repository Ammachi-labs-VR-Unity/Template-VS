using UnityEngine;
using System.Collections;

public class Faucet2Hose1 : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public HintRemove hintr;
    public Collider ccollider;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }

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
                Debug.Log("Overall hit");

                if (hit.collider.gameObject == gameObject)
                {
                    hintr.hintdis();
                    ccollider.enabled = false;
                    Debug.Log("Lid hit");

                    if (animator != null)
                    {
                        Debug.Log("Animation Triggered: " + animationname);

                        // Force animation restart
                        animator.Play(animationname, 0, 0f);
                        // Or use CrossFade for better transition handling
                        // animator.CrossFade(animationname, 0.1f);

                        StartCoroutine(WaitForAnimation());
                    }
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; // Wait 1 frame to ensure animation starts

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("Animation State Detected: " + animationState.fullPathHash);

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationname));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        Debug.Log("Animation finished!");

        screwdriverPanel.SetActive(true);
        nextButton.SetActive(true);
    }
}