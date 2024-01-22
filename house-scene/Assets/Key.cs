using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject crawlerPrefab; // Referință către prefab-ul "crawler"
    public Transform leftHand; // Referință către transform-ul mâinii stângi
    public GameObject door;
    public Transform bed;
    private bool soundPlayed = false;
    public GameObject destination;
    private bool soundPlayed2 = false;

    public AudioSource audio1; // Primul fișier audio
    public AudioSource audio3; // Al treilea fișier audio

    private float delayTimer = 0f;
    private bool delayStarted = false;

    void Start()
    {
        crawlerPrefab.SetActive(false); // Dezactivăm obiectul "crawler" la începutul jocului
        door.SetActive(false);
    }

    void Update()
    {
        // Verificăm distanța dintre leftHand și obiectul "rust_key"
        float distance = Vector3.Distance(leftHand.position, transform.position);
        float distance2 = Vector3.Distance(leftHand.position, destination.transform.position);

        if (distance2 < 7f)
        {
            if (!soundPlayed2)
            {
                audio3.Play();
                soundPlayed2 = true;
            }
        }

        if (distance < 2f)
        {
            if (!soundPlayed)
            {
                // Redă sunetul 1
                audio1.Play();
                soundPlayed = true;
            }

            door.SetActive(true);

            // Verificăm dacă prefab-ul "crawler" există și nu a fost încă instanțiat
            if (crawlerPrefab != null && GameObject.FindWithTag("crawler") == null)
            {
                // Introducem un delay de 5 secunde înainte de a activa crawler-ul
                if (!delayStarted)
                {
                    delayStarted = true;
                    delayTimer = Time.time + 7f;
                }
                else if (Time.time >= delayTimer)
                {
                    // Instanțiem obiectul "crawler" după trecerea celor 5 secunde
                    crawlerPrefab.SetActive(true);
                }
            }
        }
    }
}
