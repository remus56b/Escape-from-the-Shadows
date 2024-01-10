using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject crawlerPrefab; // Referință către prefab-ul "crawler"
    public Transform leftHand; // Referință către transform-ul mâinii stângi
    public GameObject door;

    //public AudioClip audio1; // Primul fișier audio

    void Start()
    {
        crawlerPrefab.SetActive(false); // Dezactivăm obiectul "crawler" la începutul jocului
        door.SetActive(false);
    }
    void Update()
    {
        // Verificăm distanța dintre leftHand și obiectul "rust_key"
        float distance = Vector3.Distance(leftHand.position, transform.position);

        if (distance < 2f)
        {

            //yield return new WaitForSeconds(4f);
            //AudioSource.PlayClipAtPoint(audio1, transform.position);


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
