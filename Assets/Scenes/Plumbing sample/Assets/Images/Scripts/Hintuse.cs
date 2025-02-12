using UnityEngine;
using UnityEngine.UI;

public class Hintuse : MonoBehaviour
{
    public hintManager hintm;
    public GameObject hint1;
    public Button hintbtn;

    int previousHintCount = -1;

    void Update()
    {
        if (hintm.hintCount != previousHintCount)
        {
            previousHintCount = hintm.hintCount;
           
            if (hintm.hintCount == 1)
            {
                Outline script = hint1.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.enabled = false;
            }
        }
        
    }
}