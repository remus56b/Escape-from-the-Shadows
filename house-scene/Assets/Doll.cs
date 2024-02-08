using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Doll : MonoBehaviour
{
    
    public GameObject medicine;

   
    public float rotationSpeed = 10f; // Adjust the rotation speed as needed
    public float levitateHeight = 1f; // Adjust the levitate height as needed
    public float levitateSpeed = 1f; // Adjust the levitate speed as needed

    private Vector3 originalPosition;

    void Start()
    {
        
            originalPosition = medicine.transform.position;
        
    }

    void Update()
    {
        RotateMedicine();
        LevitateMedicine();


        
    }

    void RotateMedicine()
    {
        medicine.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void LevitateMedicine()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * levitateSpeed) * levitateHeight;
        medicine.transform.position = new Vector3(medicine.transform.position.x, newY, medicine.transform.position.z);
    }
}
