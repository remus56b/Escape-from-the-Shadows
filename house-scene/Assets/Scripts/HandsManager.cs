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
    private bool isGrabbing = false;

    void Update()
    {
        isGrabbing = Input.GetKey(KeyCode.G);
        SetGrabbingTrigger(isGrabbing);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            CalculateThrowDirection();
        }
    }

    public bool IsGrabbing()
    {
        return isGrabbing;
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