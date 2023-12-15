using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator leftHand;
    [SerializeField]
    Animator rightHand;

    public float viteza = 5f; // Viteza obiectului

    private Vector3 throwDirection;
    private float throwForce = 8.0f;
    private float throwHeight = 1.0f;
    private bool isGrabbing = false;

    void Update()
    {
        HandleMovement();
        HandleGrabbing();
        HandleThrowing();
    }

    private void HandleMovement()
    {
        Vector3 directieDeplasare = Vector3.zero;

        bool apasatInainte = Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S);
        bool apasatInapoi = Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W);
        bool apasatStanga = Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);
        bool apasatDreapta = Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A);

        if (apasatInainte)
        {
            directieDeplasare += transform.forward; // Înainte
        }
        else if (apasatInapoi)
        {
            directieDeplasare -= transform.forward; // Înapoi
        }

        if (apasatStanga)
        {
            directieDeplasare -= transform.right; // Stânga
        }
        else if (apasatDreapta)
        {
            directieDeplasare += transform.right; // Dreapta
        }

        if (directieDeplasare != Vector3.zero)
        {
            directieDeplasare = directieDeplasare.normalized;
        }

        transform.Translate(directieDeplasare * viteza * Time.deltaTime, Space.Self);
    }



    private void HandleGrabbing()
    {
        isGrabbing = Input.GetKey(KeyCode.G);
        SetGrabbingTrigger(isGrabbing);
    }

    private void HandleThrowing()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CalculateThrowDirection();
        }
    }

    private void SetGrabbingTrigger(bool isGrabbing)
    {
        leftHand.SetBool("isGrabbing", isGrabbing);
        rightHand.SetBool("isGrabbing", isGrabbing);
    }

    private void CalculateThrowDirection()
    {
        Vector3 forwardDirection = Camera.main.transform.forward;
        Vector3 upwardDirection = Vector3.up * throwHeight;
        throwDirection = forwardDirection + upwardDirection;
    }
}
