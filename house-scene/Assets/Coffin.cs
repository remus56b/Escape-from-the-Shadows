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
    public AudioSource audio3;
    public GameObject demon;

    public GameObject cruce1;
    public GameObject cruce2;
    public GameObject cruce3;

    private float rotationSpeed = 50f;

    private bool isSinking = false;
    private bool hasPlayedSound = false;
    private bool hasStartedDemonAppearance = false;
    private float demonAppearSpeed = 0.5f; // Viteza de apariție a demonului
    private float demonLevSpeed = 1f; // Viteza de apariție a demonului
    private bool isLuminaCruceActive = false;

    private bool hasDemonCompletedRising = false; // Noua variabilă pentru a ține evidența terminării urcării demonului

    private float currentAudio3Volume = 0.05f; // Variabila pentru a tine evidenta intensitatii sunetului audio3
    public GameObject imagineAfisata; // Referința către obiectul Image din Canvas

    void Start()
    {
        cruce1.SetActive(false);
        cruce2.SetActive(false);
        cruce3.SetActive(false);
        audio3.volume = currentAudio3Volume;
        imagineAfisata.SetActive(false);
    }

    void ToggleLuminaCruce()
    {
        isLuminaCruceActive = !isLuminaCruceActive;

        if (isLuminaCruceActive && !hasStartedDemonAppearance)
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
        audio3.Play(); // Schimba la audio3 pentru a se asigura ca sunetul este redat
        audio2.Play();
        hasStartedDemonAppearance = true;
        hasDemonCompletedRising = true;

        // Începe creșterea treptată a intensității audio3
        InvokeRepeating("IncreaseAudio3Intensity", 0f, 7f);
        Invoke("ShowImage", 30f);


    }
    void ShowImage()
    {
        imagineAfisata.SetActive(true);
        imagineAfisata.transform.position = Camera.main.WorldToScreenPoint(demon.transform.position);
    }

        void IncreaseAudio3Intensity()
        {
            if (currentAudio3Volume < 0.28f) // Intensitatea maxima a sunetului (1.0)
            {
                currentAudio3Volume += 0.05f; // Creste intensitatea
                audio3.volume = currentAudio3Volume;
            }
            else
            {
                // Opreste invocarea pentru a evita cresteri continue dupa atingerea valorii maxime
                CancelInvoke("IncreaseAudio3Intensity");
            }
        }

    void LateUpdate()
    {
        if (hasStartedDemonAppearance && demon.transform.position.y < 8f)
        {

            luminaCrucePrefab1.SetActive(false);
            luminaCrucePrefab2.SetActive(false);
            float demonY = demon.transform.position.y + demonAppearSpeed * Time.deltaTime;
            demon.transform.position = new Vector3(demon.transform.position.x, demonY, demon.transform.position.z);
            cruce1.SetActive(true);
                cruce2.SetActive(true);
                cruce3.SetActive(true);
            RotateAroundDemon(cruce1, Vector3.up);
            RotateAroundDemon(cruce2, Vector3.up);  // Schimbă Vector3.right cu axa dorită pentru a obține orientarea corectă
            RotateAroundDemon(cruce3, Vector3.up);
            }
        else if (hasStartedDemonAppearance && hasDemonCompletedRising)
        {
            float levitateOffset = Mathf.Sin(Time.time * demonLevSpeed) * 0.5f;

            float demonY = demon.transform.position.y + levitateOffset * Time.deltaTime;
            demon.transform.position = new Vector3(demon.transform.position.x, demonY, demon.transform.position.z);

            // Rotație cruci în jurul demonului
            RotateAroundDemon(cruce1, Vector3.up);
            RotateAroundDemon(cruce2, Vector3.up);  // Schimbă Vector3.right cu axa dorită pentru a obține orientarea corectă
            RotateAroundDemon(cruce3, Vector3.up);  // Schimbă Vector3.forward cu axa dorită pentru a obține orientarea corectă
        }
    }

    void RotateAroundDemon(GameObject cruce, Vector3 axis)
    {
        cruce.transform.RotateAround(demon.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
