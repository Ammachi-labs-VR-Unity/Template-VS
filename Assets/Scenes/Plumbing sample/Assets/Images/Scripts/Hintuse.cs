using UnityEngine;
using UnityEngine.UI;
using QuickOutline;
using Outline = QuickOutline.Outline;

public class Hintuse : MonoBehaviour
{
    public hintManager hintm;
    public Button hintbtn;

    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint4;
    public GameObject hint5;
    public GameObject hint6;
    public GameObject hint7;
    public GameObject hint8;
    public GameObject hint9;
    public GameObject hint10;
    public GameObject hint11;
    public GameObject hint12;
    public GameObject hint13;
    public GameObject hint14;
    public GameObject hint15;
    public GameObject hint16;
    public GameObject hint17;
    public GameObject hint18;
    public GameObject hint19;
    public GameObject hint20;
    public GameObject hint21;
    public GameObject hint22;
    public GameObject hint23;
    public GameObject hint24;
    public GameObject hint25;
    public GameObject hint26;
    public GameObject hint27;
    public GameObject hint28;
    public GameObject hint29;
    public GameObject hint30;
    public GameObject hint31;
    public GameObject hint32;
    public GameObject hint33;
    public GameObject hint34;
    public GameObject hint35;
    public GameObject hint36;

    int previousHintCount = -1;

    private void Start()
    {
        hintbtn.onClick.AddListener(outline);
    }

    private void outline()
    {
        if (hintm.hintCount != previousHintCount)
        {
            previousHintCount = hintm.hintCount;

            if (hintm.hintCount == 1)
            {
                Outline script = hint1.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 2)
            {
                hint2.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 3)
            {
                hint3.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 4)
            {
                hint4.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 5)
            {
                Outline script = hint5.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 6)
            {
                Outline script = hint6.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 7)
            {
                Outline script = hint7.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 8)
            {
                Outline script = hint8.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 9)
            {
                Outline script = hint9.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 10)
            {
                Outline script = hint10.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 11)
            {
                Outline script = hint11.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 12)
            {
                hint12.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 13)
            {
                hint13.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 14)
            {
                Outline script = hint14.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 15)
            {
                Outline script = hint15.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 16)
            {
                Outline script = hint16.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 17)
            {
                Outline script = hint17.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 18)
            {
                Outline script = hint18.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 19)
            {
                Outline script = hint19.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 20)
            {
                Outline script = hint20.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 21)
            {
                Outline script = hint21.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 22)
            {
                Outline script = hint22.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 23)
            {
                Outline script = hint23.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 24)
            {
                Outline script = hint24.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 25)
            {
                Outline script = hint25.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 26)
            {
                hint26.SetActive(true);
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 27)
            {
                hint27.SetActive(true);
                hintbtn.interactable = false;
            }

            else if (hintm.hintCount == 28)
            {
                Outline script = hint28.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 29)
            {
                Outline script = hint29.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 30)
            {
                Outline script = hint30.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 31)
            {
                Outline script = hint31.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 32)
            {
                Outline script = hint32.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 33)
            {
                Outline script = hint33.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 34)
            {
                Outline script = hint34.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 35)
            {
                Outline script = hint35.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
            
            else if (hintm.hintCount == 36)
            {
                Outline script = hint36.GetComponent<Outline>();
                script.enabled = true;
                hintbtn.interactable = false;
            }
        }
    }
}