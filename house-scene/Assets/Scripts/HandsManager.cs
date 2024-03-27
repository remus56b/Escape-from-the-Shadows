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
    public GameObject axeInHand; // Obiectul 'HRR_Axe_01' din mână
    public GameObject axeInScene; // Obiectul 'HRR_Axe_02' din scenă
    public float activationDistance = 5.0f; // Distanța la care obiectul din mână se activează
    private MeshRenderer renderer1;

    void Start()
    {
        axeInHand = GameObject.Find("Object1538");
        axeInScene = GameObject.Find("Object1538_2");

        Debug.Log("Start function");
   
        if (axeInHand != null && axeInScene != null)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
            renderer1 = axeInHand.GetComponent<MeshRenderer>();
            renderer1.enabled = false;
        }
    }





    void Update()
    {
        HandleMovement();
        HandleGrabbing();
        HandleThrowing();
        if (renderer1 != null && renderer1.enabled == false)
        {
            HandleAxeActivation();
        }
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

    private void HandleAxeActivation()
    {
        if (axeInScene != null)
        {
            float distance = Vector3.Distance(transform.position, axeInScene.transform.position);
            if (distance < activationDistance)
            {
                Debug.Log("BBBBBBBBBB");
                if (renderer1 != null)
                {
                    renderer1.enabled = true;
                }
                axeInScene.SetActive(false);
            }
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
