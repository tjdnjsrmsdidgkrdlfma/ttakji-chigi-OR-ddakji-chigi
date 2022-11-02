using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    int left_marble;

    void Awake()
    {
        left_marble = 3;
    }

    void Update()
    {
        if (left_marble == 0)
            Debug.Log("NothingOnZone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Marble") == true)
            left_marble--;
    }
}
