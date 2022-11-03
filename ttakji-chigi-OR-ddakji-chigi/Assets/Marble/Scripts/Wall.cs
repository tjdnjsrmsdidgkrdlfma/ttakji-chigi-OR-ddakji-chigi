using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject marblemanager;

    void Awake()
    {
        marblemanager = GameObject.Find("MarbleManager");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayMarble") == true)
        {
            marblemanager.GetComponent<MarbleManager>().CreateMarble();
        }

        Destroy(other.gameObject);
    }
}
