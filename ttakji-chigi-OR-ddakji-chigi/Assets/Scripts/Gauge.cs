using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    const float x_coord = 0.5f;

    float gauge;
    float y_position;
    bool longer;

    void Awake()
    {
        gauge = 5;
        y_position = 0;
        longer = false;
    }

    void Update()
    {
        if (gauge <= 0 && longer == false)
            longer = true;
        else if (gauge >= 5 && longer == true)
            longer = false;

        if (longer == false)
            gauge -= 0.1f;
        else if (longer == true)
            gauge += 0.1f;

        y_position = gauge * 0.5f - 2.5f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y_position, gameObject.transform.position.z);
        gameObject.transform.localScale = new Vector3(x_coord, gauge, 1);

    }
}