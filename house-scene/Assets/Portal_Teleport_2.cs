using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Teleport_2 : MonoBehaviour
{
    public Transform teleportDestination;
    public Transform player;
    private GameObject doorObject;
    private Animation doorAnimation;


    private void Start()
    {
        // Găsește obiectul ușii bazat pe tag
        doorObject = GameObject.FindGameObjectWithTag("door3");
    }

    private void Update()
    {
        GameObject destination3 = GameObject.Find("destination3");

        Vector3 portalPosition = transform.position;
        Vector3 playerPosition = player.position;



        float distance = Vector3.Distance(portalPosition, playerPosition);
        if (distance < 4f)
        {
            if (destination3 != null)
            {
                player.position = destination3.transform.position;

            }
        }
    }
}
