using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = temp;
    }
}
