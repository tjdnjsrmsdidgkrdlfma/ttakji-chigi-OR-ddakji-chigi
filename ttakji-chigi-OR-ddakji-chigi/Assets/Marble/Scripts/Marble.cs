using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    bool mouse;
    bool on_process;
    bool lunched;

    Vector2 first_position;
    Vector2 last_position;

    GameObject mouse_position;
    Rigidbody2D rigidbody2d;
    AudioSource audiosource;

    void Awake()
    {
        mouse = false;
        on_process = false;
        lunched = false;

        mouse_position = GameObject.Find("Mouse");
        rigidbody2d = GetComponent<Rigidbody2D>();
        audiosource = GameObject.Find("Temp").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (lunched == false)
            LauncheMarble();
    }

    void LauncheMarble()
    {
        if (Input.GetMouseButton(0) == true && mouse == true)
        {
            on_process = true;
            first_position = mouse_position.transform.position;
        }
        if (Input.GetMouseButtonUp(0) == true && mouse == false && on_process == true)
        {
            lunched = true;
            on_process = false;
            last_position = mouse_position.transform.position;
            Vector2 temp = first_position - last_position;
            rigidbody2d.velocity = temp * 5;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mouse") == true)
            mouse = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mouse") == true)
            mouse = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Marble") == true)
            audiosource.PlayOneShot(Resources.Load("Marble/MarbleHit") as AudioClip);
    }
}
