using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOpenChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject rustKey; // Obiectul "rust_key"
    [SerializeField] private GameObject door;
    public AudioSource audio1; // Componenta AudioSource pentru sunetul sound1
    public float triggerDistance = 1.0f; // Distanța la care se declanșează animația

    private bool hasPlayedSound = false;

    void Start()
    {
        door.SetActive(false);
    }

    void Update()
    {
        // Calculează distanța dintre "chest" și "rust_key"
        float distance = Vector3.Distance(transform.position, rustKey.transform.position);

        // Dacă "rust_key" este suficient de aproape, setează "openChest" pe true
        if (distance <= triggerDistance)
        {
            animator.SetBool("openChest", true);
            rustKey.SetActive(false);
            door.SetActive(true);

            // Redă sunetul doar o dată
            if (!hasPlayedSound)
            {
                audio1.Play();
                hasPlayedSound = true;
            }
        }
        else
        {
            animator.SetBool("openChest", false);
        }
    }
}
