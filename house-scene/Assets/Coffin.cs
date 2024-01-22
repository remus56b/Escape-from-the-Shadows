using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    public GameObject heart;
    public GameObject luminaCrucePrefab1;
    public GameObject luminaCrucePrefab2;
    public float sinkingSpeed = 0.2f;
    public float appearanceInterval = 0.5f;
    private bool isSinking = false;
    private float appearanceTimer = 0f;
    private bool isLuminaCruceActive = false;
    public AudioSource audio1;
    public AudioSource audio2;

    private bool hasPlayedSound = false;


    void Start()
    {
        // Inițializează programarea repetată a funcției ToggleLuminaCruce
    }

    void ToggleLuminaCruce()
    {
        isLuminaCruceActive = !isLuminaCruceActive;

        if (isLuminaCruceActive)
        {
         
            luminaCrucePrefab1.SetActive(true);
            luminaCrucePrefab2.SetActive(true);
          
        }
        else
        {
            luminaCrucePrefab1.SetActive(false);
            luminaCrucePrefab2.SetActive(false);
            
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(heart.transform.position, transform.position);

        if (distance <= 5f)
        {
            heart.transform.position = transform.position;
            isSinking = true;
        }

        if (isSinking)
        {
            InvokeRepeating("ToggleLuminaCruce", 0f, appearanceInterval);

            float sinkStep = sinkingSpeed * Time.deltaTime;
            transform.position -= new Vector3(0f, sinkStep, 0f);
            heart.transform.position -= new Vector3(0f, sinkStep, 0f);

            if (!hasPlayedSound)
            {
                audio1.Play();
                hasPlayedSound = true;

                // Adaugă un delay de 4 secunde înainte de a reda audio2
                Invoke("PlayAudio2", 11f);
            }
        }
    }

    void PlayAudio2()
    {
        audio2.Play();
    }
}
