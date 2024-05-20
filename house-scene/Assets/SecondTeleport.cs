using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTeleport : MonoBehaviour
{
    public Transform teleportDestination;
    public Transform player;
    private GameObject doorObject;
    private GameObject basemantObject;

    private Animation doorAnimation;
    public GameObject crawler; // obiectul crawler
    private MeshRenderer renderer1;
    public GameObject axeInHand; // Obiectul 'HRR_Axe_01' din mână



    private void Start()
    {
        // Găsește obiectul ușii bazat pe tag
        basemantObject = GameObject.FindGameObjectWithTag("basemant");
        doorObject = GameObject.FindGameObjectWithTag("door2");
        axeInHand = GameObject.Find("Object1538");
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
                if (crawler)
                {
                    crawler.SetActive(false);
                }
                    basemantObject.SetActive(false);
                renderer1 = axeInHand.GetComponent<MeshRenderer>();
                renderer1.enabled = false;

            }
        }
        else
        { if (distance > 30f)
            {
                if (crawler != null)
                {
                    crawler.SetActive(false);
                }
            }
        }
    }
}
