using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public float gauge;
    public bool stop_gauge_moving;

    const float x_coord = 0.5f;

    float y_position;
    bool longer;


    void Awake()
    {
        gauge = 1;
        stop_gauge_moving = false;

        y_position = 0;
        longer = false;
    }

    void Update()
    {
        if (stop_gauge_moving == false)
            ChangeGuage();
    }

    void ChangeGuage()
    {
        if (gauge <= 0 && longer == false)
            longer = true;
        else if (gauge >= 1 && longer == true)
            longer = false;

        if (longer == false)
            gauge -= 0.02f;
        else if (longer == true)
            gauge += 0.02f;

        y_position = gauge * 2.2f - 2.2f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y_position, gameObject.transform.position.z);
        gameObject.transform.localScale = new Vector3(x_coord, gauge, 1);
    }
}