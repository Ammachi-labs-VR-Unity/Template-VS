using UnityEngine;
using System.Collections;

public class BatteryBox : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject panel;
    public GameObject nextButton;
    public GameObject batteryBox2;
    public Animator batteryBoxAnimator;
    public string animationName;

    void Start()
    {
        targetObject.SetActive(false);
        panel.SetActive(false);
        nextButton.SetActive(false);
        batteryBox2.SetActive(false);

        batteryBoxAnimator = batteryBox2.GetComponent<Animator>();
        if (batteryBoxAnimator != null)
        {
            batteryBoxAnimator.enabled = false;
        }
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
                    targetObject.SetActive(true);
                    batteryBox2.SetActive(true);
                    StartCoroutine(PlayBatteryBoxAnimation());
                }
            }
        }
    }

    private IEnumerator PlayBatteryBoxAnimation()
    {
        yield return new WaitForSeconds(2f);
        if (batteryBoxAnimator != null)
        {
            batteryBoxAnimator.enabled = true;
            batteryBoxAnimator.Play(animationName);

            // Wait until animation completes
            yield return new WaitUntil(() => !batteryBoxAnimator.GetCurrentAnimatorStateInfo(0).loop &&
                                           batteryBoxAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

            panel.SetActive(true);
            nextButton.SetActive(true);
        }
    }
}