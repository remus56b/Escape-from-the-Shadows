using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrawlerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject crawler;
    public float followSpeed = 2f;
    public float damageRate = 10f;
    public float maxHealth = 10f;
    private float currentHealth;
    public Slider healthSlider;
    public GameObject youDied;

    private float lastDamageTime;
    public float damageDelay = 0.05f; // Setează durata delay-ului în secunde

    private void Start()
    {
        currentHealth = maxHealth;
        youDied.SetActive(false);

        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned!");
        }
        else
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        lastDamageTime = Time.time; // Inițializează lastDamageTime cu timpul curent
    }

    private void Update()
    {
        if (player != null && player.activeSelf)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            transform.position += directionToPlayer.normalized * followSpeed * Time.deltaTime;

            float distanceToPlayer = directionToPlayer.magnitude;
            if (distanceToPlayer < 5.0f)
            {
                // Verifică dacă a trecut destul timp de la ultima reducere de viață
                if (Time.time - lastDamageTime >= damageDelay)
                {
                    TakeDamage(damageRate * Time.deltaTime);
                    lastDamageTime = Time.time; // Actualizează lastDamageTime cu timpul curent
                }
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

        if (currentHealth <= 0)
        {
            youDied.SetActive(true);
        }
    }
}
