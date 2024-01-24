using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrawlerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject crawler;
    public float followSpeed = 1f;
    public float damageRate = 1f;
    public float maxHealth = 10f;
    private float currentHealth;
    public Slider healthSlider;
    public ParticleSystem bloodParticles;

    private Camera mainCamera; // Adăugat referință la camera principală

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned!");
        }
        else
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        // Obține referința la camera principală
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
        }
    }

    private void Update()
    {
        if (player != null && player.activeSelf)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            transform.position += directionToPlayer.normalized * followSpeed * Time.deltaTime;

            float distanceToPlayer = directionToPlayer.magnitude;
            if (distanceToPlayer < 1.0f)
            {
                // Scade din HP-ul player-ului la o rată specificată
                TakeDamage(damageRate * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Player object is not active!");
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        // Declanșează sistemul de particule la poziția camerei principale
        if (bloodParticles != null)
        {
            bloodParticles.transform.position = mainCamera.transform.position;
            bloodParticles.Play();
        }

        if (currentHealth <= 0)
        {
            // Implementează acțiunile dorite când HP-ul ajunge la 0
            Destroy(player);
        }
    }
}
