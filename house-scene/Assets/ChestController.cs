using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class ChestController : MonoBehaviour
{
    public GameObject rustKey; // Obiectul "rust_key"
    public Animator chestAnimator; // Animatorul atașat obiectului "chest"
    public float triggerDistance = 1.0f; // Distanța la care se declanșează animația

    void Update()
    {
        // Calculează distanța dintre "chest" și "rust_key"
        float distance = Vector3.Distance(transform.position, rustKey.transform.position);

        // Dacă "rust_key" este suficient de aproape, declanșează animația
        if (distance <= triggerDistance)
        {
            chestAnimator.SetTrigger("OpenChest");
            Debug.Log("Animația de deschidere a cufărului a fost activată."); // Afișează un mesaj în consolă
        }
    }
}
