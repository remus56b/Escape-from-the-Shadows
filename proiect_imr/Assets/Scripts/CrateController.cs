using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    private ScoreboardController scoreboard;
    public float minimumDistance = 1.0f;
    public GameObject soccerBall;
    private Vector3 initialPosition;
    private bool isGrabbing = false;
    private Rigidbody soccerBallRigidbody;
    AudioSource audioSource;

    void Start()
    {
        scoreboard = GameObject.Find("Scoreboard").GetComponent<ScoreboardController>();
        initialPosition = soccerBall.transform.position;
        soccerBallRigidbody = soccerBall.GetComponent <Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanceToCrate = Vector3.Distance(soccerBall.transform.position, transform.position);
        int score = CalculateScore(distanceToCrate);
        if (distanceToCrate < minimumDistance)
        {
            scoreboard.UpdateScore(score);
            ResetSoccerBallPosition();
        }

        if (distanceToCrate > 15f)
        {
            ResetSoccerBallPosition();

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }

    private void ResetSoccerBallPosition()
    {
        soccerBall.transform.position = initialPosition;
        soccerBallRigidbody.velocity = Vector3.zero;
    }

    private int CalculateScore(float distance)
    {
        int score = Mathf.FloorToInt(1 / distance * 100000); 

        return score/1000;
    }

    public void OnGrabAction(bool isGrabbing)
    {
        this.isGrabbing = isGrabbing;
    }

    public void ThrowBall(Vector3 throwDirection)
    {
        soccerBallRigidbody.velocity = throwDirection;
    }
}
