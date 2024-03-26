using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importă biblioteca pentru lucrul cu UI

public class Lock_Door : MonoBehaviour
{
    public GameObject player; // Referință către jucător
    public GameObject canvasImage; // Referință către imaginea canvas
    public float distanceToShow = 5f; // Distanța la care să se afișeze imaginea

    void Start()
    {
        canvasImage.SetActive(false); // Dezactivează imaginea canvas la începutul jocului
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Verifică dacă distanța este mai mică decât distanța de afișare
        if (distance < distanceToShow)
        {
            // Activează imaginea canvas
            canvasImage.SetActive(true);
        }
        else
        {
            // Dezactivează imaginea canvas
            canvasImage.SetActive(false);
        }
    }
}
