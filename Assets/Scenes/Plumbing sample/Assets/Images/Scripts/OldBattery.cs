using UnityEngine;
using System.Collections;

public class OldBattery : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public Collider Collider;

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
                    Debug.Log("Lid hit");

                    if (animator != null)
                    {
                        Debug.Log("Animation Triggered: " + animationname);

                        animator.Play(animationname, 0, 0f);
                        Collider.enabled = false;

                        StartCoroutine(WaitForAnimation());
                    }
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null;

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("Animation State Detected: " + animationState.fullPathHash);

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationname));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        Debug.Log("Animation finished!");

        screwdriverPanel.SetActive(true);
        nextButton.SetActive(true);
    }
}