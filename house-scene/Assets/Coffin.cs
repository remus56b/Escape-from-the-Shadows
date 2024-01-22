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
    public AudioSource audio1;
    public AudioSource audio2;
    public GameObject demon;

    private bool isSinking = false;
    private bool hasPlayedSound = false;
    private bool hasStartedDemonAppearance = false;
    private float demonAppearSpeed = 0.5f; // Viteza de apariție a demonului
    private bool isLuminaCruceActive = false;

    void Start()
    {

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

                // Adaugă un delay de 5 secunde înainte de a reda audio2
                Invoke("PlayAudio2", 11f);
            }
        }
    }

    void PlayAudio2()
    {
        audio2.Play();
        hasStartedDemonAppearance = true;
    }

    void LateUpdate()
    {
        if (hasStartedDemonAppearance && demon.transform.position.y < 8f) // Ajustează în funcție de înălțimea dorită
        {
            float demonY = demon.transform.position.y + demonAppearSpeed * Time.deltaTime;
            demon.transform.position = new Vector3(demon.transform.position.x, demonY, demon.transform.position.z);
        }
    }
}