using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrewdriverScript : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public HintRemove hintr;
    public Button hintbtn;
    public AudioSource screwdriverAudio;

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
                    hintbtn.interactable = false;
                    animator.Play(animationname);
                    PlayScrewdriverSound();
                    StartCoroutine(WaitForAnimation());
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationname));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        screwdriverPanel.SetActive(true);
        nextButton.SetActive(true);
        StopScrewdriverSound();
    }

    void PlayScrewdriverSound()
    {
        if (screwdriverAudio != null && !screwdriverAudio.isPlaying)
        {
            screwdriverAudio.Play();
        }
    }

    void StopScrewdriverSound()
    {
        if (screwdriverAudio != null && screwdriverAudio.isPlaying)
        {
            screwdriverAudio.Stop();
        }
    }
}