using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject leftHand; // Referința către Left Hand
    public GameObject letterObject; // Referința către obiectul "letter"
    public GameObject imagineAfisata; // Referința către obiectul Image din Canvas
    public GameObject door;
    public AudioClip audio1; // Primul fișier audio
    private int letterOpened = 0; // Indicator pentru scrisoare deschisă

    void Start()
    {
        imagineAfisata.SetActive(false); // Imaginea nu este afișată la începutul jocului
        door.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(leftHand.transform.position, letterObject.transform.position);
        if (distance < 1.0f ) // Verificăm dacă mâna stângă este aproape de scrisoare și scrisoarea nu a fost deschisă încă
        {
            imagineAfisata.SetActive(true);
            imagineAfisata.transform.position = Camera.main.WorldToScreenPoint(letterObject.transform.position);
            door.SetActive(true);
            if (letterOpened == 0)
                letterOpened = 1;                
            
        }
        else
        {
            if (letterOpened == 1)
            {
                // Redă sunetul 1
                AudioSource.PlayClipAtPoint(audio1, transform.position);

                // Așteaptă până când sunetul 1 se termină și apoi redă sunetul 2
                letterOpened += 1;


            }
            imagineAfisata.SetActive(false);
        }
    }

    
}
