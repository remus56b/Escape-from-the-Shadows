using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportDestination;
    public Transform player;
    private GameObject doorObject;
    private Animation doorAnimation;

    private void Start()
    {
        // Găsește obiectul ușii bazat pe tag
        doorObject = GameObject.FindGameObjectWithTag("door");
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
        GameObject rustKeyObject = GameObject.Find("destination");

        Vector3 portalPosition = transform.position;
        Vector3 playerPosition = player.position;

        float distance = Vector3.Distance(portalPosition, playerPosition);
        if (distance < 2f)
        {
            if (rustKeyObject != null)
            {
                player.position = rustKeyObject.transform.position;

                
            }
        }
    }
}
