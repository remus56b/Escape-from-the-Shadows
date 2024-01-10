using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTeleport : MonoBehaviour
{
    public Transform teleportDestination;
    public Transform player;
    private GameObject doorObject;
    private Animation doorAnimation;


    private void Start()
    {
        // Găsește obiectul ușii bazat pe tag
        doorObject = GameObject.FindGameObjectWithTag("door2");
        if (doorObject != null)
        {
            doorAnimation = doorObject.GetComponent<Animation>();
            doorAnimation.Play("open_door");
        }
        else
        {
            Debug.LogError("Nu s-a găsit obiectul ușii!");
        }
    }

    private void Update()
    {
        GameObject destination2 = GameObject.Find("destination2");

        Vector3 portalPosition = transform.position;
        Vector3 playerPosition = player.position;



        float distance = Vector3.Distance(portalPosition, playerPosition);
        if (distance < 2f)
        {
            if (destination2 != null)
            {
                player.position = destination2.transform.position;

                

            }
        }
    }
}
