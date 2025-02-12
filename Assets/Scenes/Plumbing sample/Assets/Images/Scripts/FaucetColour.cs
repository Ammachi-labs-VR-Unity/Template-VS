using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FaucetColour : MonoBehaviour
{
    public Material material;
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint = 0f;
    public float time;

    public GameObject faucetButton;

    private Color originalColor;
    private bool isObjectInside = false;
    private bool isMoving = false;
    private Vector3 lastPosition;

    void Start()
    {
        originalColor = material.color;
        faucetButton.SetActive(false);
    }

    void Update()
    {
        if (isObjectInside && isMoving)
        {
            Transition();
        }
    }

    void Transition()
    {
        targetPoint += Time.deltaTime / time;
        material.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);

        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;

            if (targetColorIndex >= colors.Length)
            {
                targetColorIndex = colors.Length - 1;
                isObjectInside = false;
                isMoving = false;
                FaucetChangeComplete();
            }
        }
    }

    void FaucetChangeComplete()
    {
        if (faucetButton != null)
        {
            faucetButton.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cloth"))
        {
            isObjectInside = true;
            lastPosition = other.transform.position;
            StartCoroutine(CheckObjectMovement(other));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cloth"))
        {
            isObjectInside = false;
            isMoving = false;
        }
    }

    IEnumerator CheckObjectMovement(Collider other)
    {
        while (isObjectInside)
        {
            Vector3 currentPosition = other.transform.position;

            if (Vector3.Distance(currentPosition, lastPosition) > 0.01f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            lastPosition = currentPosition;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnDisable()
    {
        material.color = originalColor;
    }
}