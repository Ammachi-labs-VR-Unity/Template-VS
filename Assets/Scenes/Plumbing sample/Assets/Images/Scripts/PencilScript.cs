using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PencilScript : MonoBehaviour
{
    public Animator animator;
    public string animationName = "pencil_click";

    public GameObject objectToEnable1;
    public float enableTime1 = 1.0f;

    public GameObject objectToEnable2;
    public float enableTime2 = 2.0f;

    public GameObject second;
    public GameObject spirit;
    public Animator secondAnimator;
    public string secondAnimationName = "second_animation";

    public GameObject third;
    public GameObject box;
    public Animator thirdAnimator;
    public string thirdAnimationName = "third_animation";

    public float thirdAnimationDelay = 1.0f;

    public UnityEvent onAnimationSequenceEnd;

    private bool isPlaying = false;

    void OnMouseDown()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        isPlaying = true;
        animator.Play(animationName);

        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        if (objectToEnable1 != null)
        {
            yield return new WaitForSeconds(enableTime1);
            objectToEnable1.SetActive(true);
        }

        if (objectToEnable2 != null)
        {
            yield return new WaitForSeconds(enableTime2 - enableTime1);
            objectToEnable2.SetActive(true);
        }

        yield return new WaitForSeconds(animationLength - enableTime2);

        if (second != null)
        {
            second.SetActive(true);
            spirit.SetActive(false);
        }
        if (secondAnimator != null)
        {
            secondAnimator.Play(secondAnimationName);
            yield return new WaitForSeconds(secondAnimator.GetCurrentAnimatorStateInfo(0).length);
            second.SetActive(false);
        }

        yield return new WaitForSeconds(thirdAnimationDelay);

        if (third != null)
        {
            third.SetActive(true);
            box.SetActive(false);
        }
        if (thirdAnimator != null)
        {
            thirdAnimator.Play(thirdAnimationName);
            yield return new WaitForSeconds(thirdAnimator.GetCurrentAnimatorStateInfo(0).length);
            third.SetActive(false);
        }

        onAnimationSequenceEnd?.Invoke();

        isPlaying = false;
    }
}