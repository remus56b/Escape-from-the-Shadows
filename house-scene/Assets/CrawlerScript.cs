using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerScript : MonoBehaviour
{
    public GameObject player;  // obiectul player
    public GameObject crawler; // obiectul crawler
    public float followSpeed = 1f; // viteza de urmărire a crawler-ului

    private void Update()
    {
        // Verificăm dacă obiectul player este activ în scenă
        if (player != null && player.activeSelf)
        {
            // Calculăm direcția către player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Calculăm noua poziție a crawler-ului cu efect de urmărire
            transform.position += directionToPlayer.normalized * followSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Player object is not active!");
        }
    }
}
