using Amrita.AmmachiLabs.Game_Managers.Progress.Score_Card;
using Amrita.AmmachiLabs.Game_Managers.Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.CurrentScore >= 96)
        {
            ScoreManager.Instance.CurrentScore = 100;
        }
    }

    //public void AddScoreToQuiz()
    //{


    //    ScoreText.text = score.ToString();

    //    if (score >= 100)
    //    {
    //        threeStars.gameObject.SetActive(true);
    //        audioSource.clip = threeStarMusic;
    //        audioSource.Play();
    //    }
    //    else if (score >= 75)
    //    {
    //        twoStars.gameObject.SetActive(true);
    //        audioSource.clip = twoStarMusic;
    //        audioSource.Play();
    //    }
    //    else if (score >= 50)
    //    {
    //        OneStar.gameObject.SetActive(true);
    //        audioSource.clip = oneStarMusic;
    //        audioSource.Play();
    //    }
    //    else
    //    {
    //        zeroStars.gameObject.SetActive(true);
    //        audioSource.clip = noStarMusic;
    //        audioSource.Play();
    //    }
    //}
}