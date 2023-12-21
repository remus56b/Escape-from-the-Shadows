using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject leftHand; // Referința către Left Hand
    public GameObject letterObject; // Referința către obiectul "letter"
    public GameObject imagineAfisata; // Referința către obiectul Image din Canvas

    void Start()
    {
        imagineAfisata.SetActive(false); // Imaginea nu este afișată la începutul jocului
    }

    void Update()
    {
        float distance = Vector3.Distance(leftHand.transform.position, letterObject.transform.position);
        if (distance < 1.0f)
        {
            imagineAfisata.SetActive(true);
            imagineAfisata.transform.position = Camera.main.WorldToScreenPoint(letterObject.transform.position);
        }
        else
        {
            imagineAfisata.SetActive(false);
        }
    }
}