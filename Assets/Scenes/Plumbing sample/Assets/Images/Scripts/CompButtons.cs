using UnityEngine;
using UnityEngine.UI;

public class CompButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons; 
    [SerializeField] private GameObject continuebtn;

    void Update()
    {
        bool allActive = allareActive();

        if(allActive)
        {
            continuebtn.SetActive(true);
        }

        else
        {
            continuebtn.SetActive(false);
        }

        //continuebtn.interactable = allActive;
    }

    private bool allareActive()
    {
        foreach (GameObject obj in buttons)
        {
            if (obj != null && !obj.activeSelf)
                return false;
        }
        return true;
    }
}