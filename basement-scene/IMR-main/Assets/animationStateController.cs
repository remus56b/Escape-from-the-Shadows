using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    HandsManager handsManager; // Adaugă acest câmp pentru a face referire la HandsManager

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (handsManager != null)
        {
            bool isGrabbing = handsManager.IsGrabbing();

            if (isGrabbing)
            {
                bool hasGrabbedKey = CheckIfPlayerGrabbedKey();

                if (hasGrabbedKey)
                {
                    animator.SetBool("isJumping", true);
                }
            }
        }
    }

    private bool CheckIfPlayerGrabbedKey()
    {
        // Presupunem că avem un obiect numit "rust_key" în scena
        GameObject key = GameObject.Find("rust_key");

        if (key == null)
        {
            // Dacă nu există un obiect numit "rust_key", returnează false
            return false;
        }

        // Verifică dacă jucătorul a intrat în coliziune cu cheia
        Collider keyCollider = key.GetComponent<Collider>();
        Collider playerCollider = GetComponent<Collider>();

        if (keyCollider.bounds.Intersects(playerCollider.bounds))
        {
            // Dacă jucătorul a intrat în coliziune cu cheia, returnează true
            return true;
        }

        // Dacă jucătorul nu a intrat în coliziune cu cheia, returnează false
        return false;
    }
}