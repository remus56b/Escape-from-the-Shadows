using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject leftHand; 
    public GameObject letterObject; 
    public GameObject imagineAfisata; 
    public GameObject door;
    public AudioSource audio1; 
    private int letterOpened = 0; 

    void Start()
    {
        imagineAfisata.SetActive(false); 
        door.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(leftHand.transform.position, letterObject.transform.position);
        if (distance < 2.0f ) 
        {
            imagineAfisata.SetActive(true);
            imagineAfisata.transform.position = Camera.main.WorldToScreenPoint(letterObject.transform.position);
            door.SetActive(true);
            if (letterOpened == 0)
                letterOpened = 1;                
            
        }
        else
        {
            if (letterOpened == 1)
            {
                audio1.Play();
                letterOpened += 1;
            }
            imagineAfisata.SetActive(false);
        }
    }
}
