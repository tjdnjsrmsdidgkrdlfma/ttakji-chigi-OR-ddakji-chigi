using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    GameObject end_line;
    GameObject success;
    GameObject monster;
    GameObject player;

    void Awake()
    {
        end_line = GameObject.Find("EndLine");
        success = GameObject.Find("Canvas").transform.Find("Success").gameObject;
        monster = GameObject.Find("FlowerManager");
        player = GameObject.Find("Player");
    }

    void Start()
    {
        Color invisible = new Color(1, 1, 1, 0);
        end_line.GetComponent<SpriteRenderer>().color = invisible;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            monster.GetComponent<FlowerManager>().StopFlipFace();
            player.GetComponent<Up>().enabled = false;
            success.SetActive(true);
        }
    }
}