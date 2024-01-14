using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOpenChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject rustKey; // Obiectul "rust_key"
    public float triggerDistance = 1.0f; // Distanța la care se declanșează animația

    void Update()
    {
        // Calculează distanța dintre "chest" și "rust_key"
        float distance = Vector3.Distance(transform.position, rustKey.transform.position);

        // Dacă "rust_key" este suficient de aproape, setează "openChest" pe true
        if (distance <= triggerDistance)
        {
            animator.SetBool("openChest", true);
        }
        else
        {
            animator.SetBool("openChest", false);
        }
    }
}
