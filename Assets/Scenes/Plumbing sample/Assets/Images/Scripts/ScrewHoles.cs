using UnityEngine;
using UnityEngine.UI;

public class ScrewHoles : MonoBehaviour
{
    public string positionType;
    public Animator targetAnimator;

    public string leftNormalAnimation = "left_normal_animation";
    public string leftHoldAnimation = "left_hold_animation";
    public string leftFinalAnimation = "left_final_animation";

    public string rightNormalAnimation = "right_normal_animation";
    public string rightHoldAnimation = "right_hold_animation";
    public string rightFinalAnimation = "right_final_animation";

    public GameObject drillpanel;
    public GameObject nextButton;
    public GameObject drill;
    public BoxCollider drillCollider;
    public GameObject leftscrew;
    public GameObject rightscrew;

    private bool canUseDrill = false;
    private bool isDrillHeld = false;
    private bool isHoldAnimationPlaying = false;
    private float holdAnimationProgress = 0f;

    private static bool leftCompleted = false;
    private static bool rightCompleted = false;

    public AudioSource drillAudio;

    public Collider othercollider;

    void Start()
    {
        leftCompleted = false;
        rightCompleted = false;

        if (drill != null)
        {
            drillCollider = drill.GetComponent<BoxCollider>();
            if (drillCollider != null)
            {
                drillCollider.enabled = false;
            }
        }

        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (targetAnimator != null)
        {
            PlayNormalAnimation();
        }
    }

    void PlayNormalAnimation()
    {
        if (targetAnimator != null)
        {
            if (positionType == "left" && !leftCompleted)
            {
                othercollider.enabled = false;
                targetAnimator.Play(leftNormalAnimation);
            }
            else if (positionType == "right" && !rightCompleted)
            {
                othercollider.enabled = false;
                targetAnimator.Play(rightNormalAnimation);
            }

            float animationLength = targetAnimator.GetCurrentAnimatorStateInfo(0).length;
            Invoke(nameof(EnableDrill), animationLength);
        }
    }

    void EnableDrill()
    {
        if (drillCollider != null)
        {
            drillCollider.enabled = true;
            canUseDrill = true;
        }
    }

    void Update()
    {
        if (canUseDrill && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider == drillCollider)
            {
                isDrillHeld = true;
                ResumeHoldAnimation();
            }
        }

        else if (isDrillHeld && !Input.GetMouseButton(0))
        {
            isDrillHeld = false;
            PauseHoldAnimation();
        }

        if (isHoldAnimationPlaying)
        {
            AnimatorStateInfo stateInfo = targetAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName(positionType == "left" ? leftHoldAnimation : rightHoldAnimation) && stateInfo.normalizedTime >= 1.0f)
            {
                PlayFinalAnimation();
            }
        }

        if (leftCompleted && rightCompleted && nextButton != null)
        {
            nextButton.SetActive(true);
        }
    }

    void ResumeHoldAnimation()
    {
        if (targetAnimator != null && isHoldAnimationPlaying)
        {
            targetAnimator.speed = 1;

            if (drillAudio != null && !drillAudio.isPlaying)
            {
                drillAudio.Play();
            }
        }
        else
        {
            PlayHoldAnimation();
        }
    }

    void PauseHoldAnimation()
    {
        if (targetAnimator != null && isHoldAnimationPlaying)
        {
            holdAnimationProgress = targetAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            targetAnimator.speed = 0;

            if (drillAudio != null && drillAudio.isPlaying)
            {
                drillAudio.Pause();
            }
        }
    }

    void PlayHoldAnimation()
    {
        if (targetAnimator != null)
        {
            string holdAnimation = positionType == "left" ? leftHoldAnimation : rightHoldAnimation;
            if ((positionType == "left" && !leftCompleted) || (positionType == "right" && !rightCompleted))
            {
                targetAnimator.Play(holdAnimation, 0, holdAnimationProgress);
                targetAnimator.speed = 1;
                isHoldAnimationPlaying = true;
            }

            if (drillAudio != null && !drillAudio.isPlaying)
            {
                drillAudio.Play();
            }
        }
    }

    void PlayFinalAnimation()
    {
        if (targetAnimator != null)
        {
            if (positionType == "left" && !leftCompleted)
            {
                drillAudio.Stop();
                leftscrew.SetActive(true);
                othercollider.enabled = true;
                targetAnimator.Play(leftFinalAnimation);
                leftCompleted = true;
            }
            else if (positionType == "right" && !rightCompleted)
            {
                drillAudio.Stop();
                rightscrew.SetActive(true);
                othercollider.enabled = true;
                targetAnimator.Play(rightFinalAnimation);
                rightCompleted = true;
            }
            ResetForNextScrew();
        }
    }

    void ResetForNextScrew()
    {
        canUseDrill = false;
        drillCollider.enabled = false;
        isDrillHeld = false;
        isHoldAnimationPlaying = false;
        holdAnimationProgress = 0f;

        if (leftCompleted && rightCompleted)
        {
            drillpanel.SetActive(true);
            nextButton.SetActive(true);
        }
    }
}