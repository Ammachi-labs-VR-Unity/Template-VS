using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using QuickOutline;
using Outline = QuickOutline.Outline;
public class HintRemove : MonoBehaviour
{
    public static HintRemove Instance;
    public hintManager hintm;
    public Button hintbtn;

    public GameObject hint1;
    public GameObject hint2;
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

    public void Start()
    {
        Instance = this;
    }
    public void hintdis()
    {
        if (hintm.hintCount == 1)
        {
            hintbtn.interactable = false;
            Outline script = hint1.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 2)
        {
            hintbtn.interactable = false;
            hint2.SetActive(false);
        }

        else if (hintm.hintCount == 3)
        {
            hintbtn.interactable = false;
        }

        else if (hintm.hintCount == 4)
        {
            hintbtn.interactable = false;
            hint2.SetActive(false);
        }

        else if (hintm.hintCount == 5)
        {
            hintbtn.interactable = false;
            Outline script = hint5.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 6)
        {
            hintbtn.interactable = false;
            Outline script = hint6.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 7)
        {
            hintbtn.interactable = false;
            Outline script = hint7.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 8)
        {
            hintbtn.interactable = false;
            Outline script = hint8.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 9)
        {
            hintbtn.interactable = false;
            Outline script = hint9.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 10)
        {
            hintbtn.interactable = false;
            Outline script = hint10.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 11)
        {
            hintbtn.interactable = false;
            Outline script = hint11.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 12)
        {
            hintbtn.interactable = false;
            hint12.SetActive(false);
        }

        else if (hintm.hintCount == 13)
        {
            hintbtn.interactable = false;
            hint13.SetActive(false);
        }

        else if (hintm.hintCount == 14)
        {
            hintbtn.interactable = false;
            Outline script = hint14.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 15)
        {
            hintbtn.interactable = false;
            Outline script = hint15.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 16)
        {
            hintbtn.interactable = false;
            Outline script = hint16.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 17)
        {
            hintbtn.interactable = false;
            Outline script = hint17.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 18)
        {
            hintbtn.interactable = false;
            Outline script = hint18.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 19)
        {
            hintbtn.interactable = false;
            Outline script = hint19.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 20)
        {
            hintbtn.interactable = false;
            Outline script = hint20.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 21)
        {
            hintbtn.interactable = false;
            Outline script = hint21.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 22)
        {
            hintbtn.interactable = false;
            Outline script = hint22.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 23)
        {
            hintbtn.interactable = false;
            Outline script = hint23.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 24)
        {
            hintbtn.interactable = false;
            Outline script = hint24.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 25)
        {
            hintbtn.interactable = false;
            Outline script = hint25.GetComponent<Outline>();
            script.enabled = false;
        }

        else if (hintm.hintCount == 26)
        {
            hintbtn.interactable = false;
            hint26.SetActive(false);
        }
        
        else if (hintm.hintCount == 27)
        {
            hintbtn.interactable = false;
            hint27.SetActive(false);
        }

        else if (hintm.hintCount == 28)
        {
            hintbtn.interactable = false;
            Outline script = hint28.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 29)
        {
            hintbtn.interactable = false;
            Outline script = hint29.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 30)
        {
            hintbtn.interactable = false;
            Outline script = hint30.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 31)
        {
            hintbtn.interactable = false;
            Outline script = hint31.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 32)
        {
            hintbtn.interactable = false;
            Outline script = hint32.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 33)
        {
            hintbtn.interactable = false;
            Outline script = hint33.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 34)
        {
            hintbtn.interactable = false;
            Outline script = hint34.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 35)
        {
            hintbtn.interactable = false;
            Outline script = hint35.GetComponent<Outline>();
            script.enabled = false;
        }
        
        else if (hintm.hintCount == 36)
        {
            hintbtn.interactable = false;
            Outline script = hint36.GetComponent<Outline>();
            script.enabled = false;
        }
    }
}
