using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    [SerializeField]
    Animator leftHand;
    [SerializeField]
    Animator rightHand;

    private Vector3 throwDirection;
    private float throwForce = 8.0f;
    private float throwHeight = 1.0f; 

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            SetGrabbingTrigger(true);
        }
        else
        {
            SetGrabbingTrigger(false);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            CalculateThrowDirection();
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            CrateController crateController = GameObject.Find("Crate").GetComponent<CrateController>();
            crateController.ThrowBall(throwDirection.normalized * throwForce);
        }
    }

    private void CalculateThrowDirection()
    {
        Vector3 forwardDirection = Camera.main.transform.forward;
        Vector3 upwardDirection = Vector3.up * throwHeight;
        throwDirection = forwardDirection + upwardDirection;
    }

    private void SetGrabbingTrigger(bool isGrabbing)
    {
        leftHand.SetBool("isGrabbing", isGrabbing);
        rightHand.SetBool("isGrabbing", isGrabbing);
    }
}
