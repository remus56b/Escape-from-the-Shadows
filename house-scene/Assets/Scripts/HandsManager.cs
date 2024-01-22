using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator leftHand;
    [SerializeField]
    Animator rightHand;

    public float viteza = 15f; // Viteza obiectului

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

        bool apasatInainte = Input.GetKey(KeyCode.W);
        bool apasatInapoi = Input.GetKey(KeyCode.S);
        bool apasatStanga = Input.GetKey(KeyCode.A);
        bool apasatDreapta = Input.GetKey(KeyCode.D);

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        if (apasatInainte)
        {
            directieDeplasare += forward; // Înainte
        }
        else if (apasatInapoi)
        {
            directieDeplasare -= forward; // Înapoi
        }

        if (apasatStanga)
        {
            directieDeplasare -= right; // Stânga
        }
        else if (apasatDreapta)
        {
            directieDeplasare += right; // Dreapta
        }

        if (directieDeplasare != Vector3.zero)
        {
            directieDeplasare.Normalize();
            transform.Translate(directieDeplasare * viteza * Time.deltaTime, Space.World);
        }
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
