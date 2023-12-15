using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float viteza = 5f; // Viteza obiectului

    void Update()
    {
        // Inițializează o variabilă pentru direcția de deplasare
        Vector3 directieDeplasare = Vector3.zero;

        // Verifică tastele pentru a seta direcția de deplasare
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.G))
        {
            directieDeplasare += transform.forward; // Înainte
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.G))
        {
            directieDeplasare -= transform.forward; // Înapoi
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.G))
        {
            directieDeplasare -= transform.right; // Stânga
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.G))
        {
            directieDeplasare += transform.right; // Dreapta
        }

        // Normalizează direcția de deplasare pentru a menține viteza constantă în toate direcțiile
        if (directieDeplasare != Vector3.zero)
        {
            directieDeplasare = directieDeplasare.normalized;
        }

        // Aplică mișcarea în direcția specificată
        transform.Translate(directieDeplasare * viteza * Time.deltaTime);

        // Alte funcții sau logici pentru mișcarea obiectului pot fi adăugate aici în funcție de necesități
    }
}