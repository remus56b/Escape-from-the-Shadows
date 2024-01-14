using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOpenDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player; // Obiectul "Player"
    public float triggerDistance = 1.0f; // Distanța la care se declanșează animația

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculează distanța dintre "door" și "Player"
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Dacă "Player" este suficient de aproape, setează "openDoor" pe true
        if (distance <= triggerDistance)
        {
            animator.SetBool("openDoor", true);
        }
        else
        {
            animator.SetBool("openDoor", false);
        }
    }
}
