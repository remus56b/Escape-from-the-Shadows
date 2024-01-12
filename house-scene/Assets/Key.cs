using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject crawlerPrefab; // Referință către prefab-ul "crawler"
    public Transform leftHand; // Referință către transform-ul mâinii stângi
    public GameObject door;
    private bool soundPlayed = false; 
    public GameObject destination;
    public bool soundPlayed2 = false;

    public AudioClip audio1; // Primul fișier audio
    public AudioClip audio2; 
    public AudioClip audio3; // Al treilea fișier audio

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
                AudioSource.PlayClipAtPoint(audio2, transform.position);
                //play sound 3 after sound 2 is finished
                AudioSource.PlayClipAtPoint(audio3, transform.position);

                soundPlayed2 = true;
            }
        }

        if (distance < 2f)
        {
            if (!soundPlayed)
            {
                // Redă sunetul 1
                AudioSource.PlayClipAtPoint(audio1, transform.position);
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
                    delayTimer = Time.time + 5f;
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
