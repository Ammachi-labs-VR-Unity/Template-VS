using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandScript : MonoBehaviour
{
    private Animator animator;
    public string animationname;
    public GameObject screwdriverPanel;
    public GameObject nextButton;
    public GameObject waterflow;
    public Collider handcollider;
    public HintRemove hintr;
    public Button hintbtn;
    public AudioSource waterAudio;


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
                    handcollider.enabled = false;
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

        waterflow.SetActive(true);
        PlayWaterSound();

        yield return new WaitForSeconds(2);

        screwdriverPanel.SetActive(true);
        nextButton.SetActive(true);
    }

    void PlayWaterSound()
    {
        if (waterAudio != null && !waterAudio.isPlaying)
        {
            waterAudio.Play();
        }
    }
}