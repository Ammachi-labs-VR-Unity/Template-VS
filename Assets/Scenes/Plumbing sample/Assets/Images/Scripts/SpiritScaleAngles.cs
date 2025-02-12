using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ValueNavigator : MonoBehaviour
{
    public Button upButton, downButton, submitButton, retryButton;
    public GameObject[] linkedObjects;
    public Image[] linkedImages;
    public Image errorImage;
    public UnityEvent ControlBox;

    private int[] values = { -15, -10, -5, 0, 5, 10, 15 };
    private int currentIndex = 6;

    void Start()
    {
        upButton.onClick.AddListener(IncreaseValue);
        downButton.onClick.AddListener(DecreaseValue);
        submitButton.onClick.AddListener(CheckSelection);
        retryButton.onClick.AddListener(HideError);

        errorImage.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateGameObjectState();
    }

    void IncreaseValue()
    {
        if (currentIndex < values.Length - 1)
        {
            currentIndex++;
            UpdateGameObjectState();
        }
    }

    void DecreaseValue()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateGameObjectState();
        }
    }

    void CheckSelection()
    {
        upButton.interactable = false;
        downButton.interactable = false;

        if (currentIndex == 3)
        {
            ControlBox.Invoke();
            Debug.Log("Correct selection! Event triggered.");
        }
        else
        {
            errorImage.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            submitButton.gameObject.SetActive(false);
        }
    }

    void HideError()
    {
        upButton.interactable = true;
        downButton.interactable = true;

        errorImage.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(true);
    }

    void UpdateGameObjectState()
    {
        foreach (GameObject obj in linkedObjects)
        {
            obj.SetActive(false);
        }

        foreach (Image img in linkedImages)
        {
            img.gameObject.SetActive(false);
        }

        if (currentIndex >= 0 && currentIndex < linkedObjects.Length)
        {
            linkedObjects[currentIndex].SetActive(true);
        }

        if (currentIndex >= 0 && currentIndex < linkedImages.Length)
        {
            linkedImages[currentIndex].gameObject.SetActive(true);
        }
    }
}