using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{
    bool mouse;
    bool on_process;

    Vector2 first_position;
    Vector2 last_position;

    Rigidbody2D rigidbody2d;

    GameObject mouse_position;

    void Awake()
    {
        mouse = false;
        on_process = false;

        rigidbody2d = GetComponent<Rigidbody2D>();

        mouse_position = GameObject.Find("Mouse");
    }

    void Update()
    {
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mouse") == true)
            mouse = false;
    }
}
