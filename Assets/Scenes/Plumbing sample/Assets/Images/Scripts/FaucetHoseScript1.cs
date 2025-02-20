using UnityEngine;
using System.Collections;

public class FaucetHoseScript1 : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public HintRemove hintr;
    public AudioSource clickAudio;


    void Start()
    {
        animator = GetComponent<Animator>();
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
                    animator.Play(animationname);
                    PlayClickSound();
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
        StopClickSound();
    }

    void PlayClickSound()
    {
        if (clickAudio != null && !clickAudio.isPlaying)
        {
            clickAudio.Play();
        }
    }

    void StopClickSound()
    {
        if (clickAudio != null && clickAudio.isPlaying)
        {
            clickAudio.Stop();
        }
    }
}