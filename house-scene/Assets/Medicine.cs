using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Medicine : MonoBehaviour
{
    public GameObject player;
    public GameObject hpBar;
    public GameObject medicine;

    public float maxDistance = 16f;
    public float maxHealth = 10f;
    public float rotationSpeed = 10f; // Adjust the rotation speed as needed
    public float levitateHeight = 1f; // Adjust the levitate height as needed
    public float levitateSpeed = 1f; // Adjust the levitate speed as needed

    private Vector3 originalPosition;

    void Start()
    {
        Debug.Log("Medicine script started!");
        if (player == null || hpBar == null || medicine == null)
        {
            Debug.LogError("Player, HP Bar, or Medicine not assigned!");
        }
        else
        {
            originalPosition = medicine.transform.position;
        }
    }

    void Update()
    {
        RotateMedicine();
        LevitateMedicine();


        if (player != null && hpBar != null && medicine != null)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, medicine.transform.position);
            if (distanceToPlayer < maxDistance)
            {
                hpBar.GetComponent<Slider>().value = maxHealth;
                medicine.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Player, HP Bar, or Medicine not assigned!");
        }
    }

    void RotateMedicine()
    {
        medicine.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void LevitateMedicine()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * levitateSpeed) * levitateHeight;
        medicine.transform.position = new Vector3(medicine.transform.position.x, newY, medicine.transform.position.z);
    }
}
