using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject crawlerPrefab; // Referință către prefab-ul "crawler"
    public Transform leftHand; // Referință către transform-ul mâinii stângi
    public GameObject door;
    private bool soundPlayed = false; 
    public GameObject destination;
    public bool soundPlayed2= false;


    public AudioClip audio1; // Primul fișier audio
    public AudioClip audio2; 


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
                //yield return new WaitForSeconds(10f);
                AudioSource.PlayClipAtPoint(audio2, transform.position);
                soundPlayed2 = true;
            }
        }

        if (distance < 2f)
        {

            
            if (!soundPlayed)
            {
                //yield return new WaitForSeconds(10f);
                // Redă sunetul 1
                AudioSource.PlayClipAtPoint(audio1, transform.position);
                soundPlayed = true;
            }


            door.SetActive(true);
            // Verificăm dacă prefab-ul "crawler" există și nu a fost încă instanțiat
            if (crawlerPrefab != null && GameObject.FindWithTag("crawler") == null)
            {
                // Instanțiem obiectul "crawler" în cazul în care nu există încă în scenă
                crawlerPrefab.SetActive(true);


            }
        }
    }
}
