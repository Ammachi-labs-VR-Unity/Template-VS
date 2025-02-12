using UnityEngine;
using System.Collections;

public class LidScrew : MonoBehaviour
{
    public GameObject screwdriver;
    public GameObject cam;
    public Animator animator;
    public string anima;
    public GameObject environment;
    public GameObject panel;
    public GameObject nextbutton;
    public GameObject box2;
    public Collider screw1;

    void Start()
    {
        
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
                    cam.SetActive(true);                    
                    box2.SetActive(false);
                    screwdriver.SetActive(true);
                    environment.SetActive(true);

                    animator.Play(anima, 0, 0f);
                    StartCoroutine(WaitForAnimation());
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return null; 

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log("Animation State Detected: " + animationState.fullPathHash);

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(anima));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        Debug.Log("Animation finished!");

        screw1.enabled = false;
        panel.SetActive(true);
        nextbutton.SetActive(true);
    }
}
