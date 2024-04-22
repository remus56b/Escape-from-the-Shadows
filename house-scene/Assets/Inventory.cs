using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public GameObject axe; 
    public GameObject key;


    void Start()
    {
    }

    void Update()
    {
        float distanceToKey = Vector3.Distance(transform.position, key.transform.position);

        if (distanceToKey < 6f)
        {

            key.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

}
