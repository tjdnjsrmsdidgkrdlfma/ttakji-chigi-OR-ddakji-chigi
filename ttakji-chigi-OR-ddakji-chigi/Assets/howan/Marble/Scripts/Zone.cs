using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    bool marbles_on_zone;

    void Awake()
    {
        marbles_on_zone = false;
    }

    void Update()
    {
        if(marbles_on_zone==true)
        {
            Debug.Log("Safe");
        }
        else
        {
            Debug.Log("Out");
        }

        marbles_on_zone = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Marble") == true)
            marbles_on_zone = true;
    }
}
