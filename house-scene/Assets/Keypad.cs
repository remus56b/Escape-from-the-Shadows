using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keypad : MonoBehaviour
{
    string Code = "422";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;
    public GameObject door;
    public GameObject door3;
    public GameObject keypad;



    void Start()
    {
        door.SetActive(false);

    }
    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;

    }
    public void Enter()
    {
        if (Nr == Code)
        {
            door.SetActive(true);
            Destroy(gameObject);
            Destroy(door3);
            door3.SetActive(false);

        }
       
        
    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}