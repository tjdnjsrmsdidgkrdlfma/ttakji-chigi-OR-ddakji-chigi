using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    int left_marble;

    GameObject marble_manager;

    void Awake()
    {
        left_marble = 3;

        marble_manager = GameObject.Find("MarbleManager");
    }

    void Update()
    {
        if (left_marble == 0)
            marble_manager.GetComponent<MarbleManager>().ShowResult(true);
        else if (left_marble > 0 && marble_manager.GetComponent<MarbleManager>().max_create_marble < 0)
            marble_manager.GetComponent<MarbleManager>().ShowResult(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Marble") == true)
            left_marble--;
    }
}
