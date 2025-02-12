using UnityEngine;
using UnityEngine.UI;

public class ButtonOnOff : MonoBehaviour
{
    public Button toggleButton;
    public Image targetImage;
    private bool isImageVisible = false;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleImageVisibility);
        targetImage.gameObject.SetActive(isImageVisible);

    }

    void ToggleImageVisibility()
    {
        isImageVisible = !isImageVisible;
        targetImage.gameObject.SetActive(isImageVisible);
    }
}