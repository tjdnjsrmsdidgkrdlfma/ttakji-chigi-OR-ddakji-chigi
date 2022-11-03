using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    float move_distance;
    public bool is_walking;

    public Animator animator;

    void Awake()
    {
        move_distance = 0.001f;
        is_walking = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            transform.position = new Vector3(0, transform.position.y + move_distance, 0);
            is_walking = true;
            animator.SetBool("isWalking", is_walking);
        }
        else
        {
            is_walking = false;
            animator.SetBool("isWalking", is_walking);
        }
    }
}