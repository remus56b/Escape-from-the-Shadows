using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardController : MonoBehaviour
{
    TextMeshPro tmpro;
    float totalScore;
    AudioSource audioSource;

    void Start()
    {
        tmpro = gameObject.GetComponent<TextMeshPro>();
        totalScore = 0;
        audioSource = GetComponent<AudioSource>(); 
    }

    public void UpdateScore(float score)
    {
        totalScore += score;
        tmpro.text = "Score: " + totalScore;

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
