using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportDestination;
    public Transform player;
    public AudioClip teleportSound; // Sunetul pentru teleportare

    private void Update()
    {
        GameObject rustKeyObject = GameObject.Find("destination");

        Vector3 portalPosition = transform.position;

        Vector3 playerPosition = player.position;

        float distance = Vector3.Distance(portalPosition, playerPosition);
        if (distance < 3f)
        {
            if (rustKeyObject != null)
            {
                player.position = rustKeyObject.transform.position;

                // Redă sunetul pentru teleportare la poziția portalului
                AudioSource.PlayClipAtPoint(teleportSound, portalPosition);
            }
        }
    }
}
