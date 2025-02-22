using UnityEngine;
using UnityEngine.UI;

public class ButtonOnOff : MonoBehaviour
{
    public Button toggleButton;
    public Image targetImage;

    void Start()
    {
        targetImage.gameObject.SetActive(false);
        toggleButton.onClick.AddListener(EnableImage);
    }

    void EnableImage()
    {
        targetImage.gameObject.SetActive(true);
        toggleButton.interactable = false;
        toggleButton.onClick.RemoveListener(EnableImage);
    }
}