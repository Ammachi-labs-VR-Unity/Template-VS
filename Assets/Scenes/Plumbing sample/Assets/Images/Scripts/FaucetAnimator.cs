using Amrita.AmmachiLabs.Game_Managers.Quiz;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FaucetAnimator : MonoBehaviour
{
    private Animator animator;
    public float delay = 2f;

    void OnEnable()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("Animator component not found on " + gameObject.name);
            return;
        }

        StartCoroutine(DisableAnimator());
    }

    IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = false;
        Debug.Log("Animator disabled after " + delay + " seconds.");
    }
}