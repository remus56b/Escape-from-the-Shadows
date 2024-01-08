using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject crawlerPrefab; // Referință către prefab-ul "crawler"
    public Transform leftHand; // Referință către transform-ul mâinii stângi
    void Start()
    {
        crawlerPrefab.SetActive(false); // Dezactivăm obiectul "crawler" la începutul jocului
    }
    void Update()
    {
        // Verificăm distanța dintre leftHand și obiectul "rust_key"
        float distance = Vector3.Distance(leftHand.position, transform.position);

        if (distance < 2f)
        {
            // Verificăm dacă prefab-ul "crawler" există și nu a fost încă instanțiat
            if (crawlerPrefab != null && GameObject.FindWithTag("crawler") == null)
            {
                // Instanțiem obiectul "crawler" în cazul în care nu există încă în scenă
                crawlerPrefab.SetActive(true);
            }
        }
    }
}
