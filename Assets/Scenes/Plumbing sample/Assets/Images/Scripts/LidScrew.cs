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
    public HintRemove hintr;
    public AudioSource screwAudio;

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
                    cam.SetActive(true);
                    box2.SetActive(false);
                    screwdriver.SetActive(true);
                    environment.SetActive(true);
                    screw1.enabled = false;

                    animator.Play(anima, 0, 0f);
                    PlayScrewSound();
                    StartCoroutine(WaitForAnimation());
                }
            }
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(anima));

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0));

        Debug.Log("Animation finished!");
        StopScrewSound();
        panel.SetActive(true);
        nextbutton.SetActive(true);
    }

    void PlayScrewSound()
    {
        if (screwAudio != null && !screwAudio.isPlaying)
        {
            screwAudio.Play();
        }
    }

    void StopScrewSound()
    {
        if (screwAudio != null && screwAudio.isPlaying)
        {
            screwAudio.Stop();
        }
    }
}