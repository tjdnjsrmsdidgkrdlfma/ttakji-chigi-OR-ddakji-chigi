using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    GameObject marble_manager;
    GameObject monster;
    GameObject player;
    BoxCollider2D collider2d;

    void Awake()
    {
        marble_manager = GameObject.Find("FlowerManager");
        monster = GameObject.Find("FlowerManager");
        player = GameObject.Find("Player");
        collider2d = GameObject.Find("EndLine").GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            monster.GetComponent<FlowerManager>().StopFlipFace();
            player.GetComponent<Up>().enabled = false;
            marble_manager.GetComponent<FlowerManager>().ShowResult(true);
            collider2d.enabled = false;
        }
    }
}