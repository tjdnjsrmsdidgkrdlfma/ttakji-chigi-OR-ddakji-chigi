using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarbleManager : MonoBehaviour
{
    float max_create_marble;

    GameObject playmarble_prefab;
    GameObject[] marbles;
    TextMeshProUGUI left_marble_number;

    void Awake()
    {
        max_create_marble = 2;

        playmarble_prefab = Resources.Load("Marble/PlayMarble") as GameObject;
        marbles = GameObject.FindGameObjectsWithTag("Marble");
        left_marble_number = GameObject.Find("Canvas/LeftMarbleNumber").GetComponent<TextMeshProUGUI>();

        SetPosition();
    }

    void SetPosition()
    {
        float x_coordinate;
        float y_coordinate;

        for (int i = 0; i < 3; i++)
        {
            x_coordinate = Random.Range(-2.06f, 2.06f);
            y_coordinate = Mathf.Sqrt((2.06f * 2.06f) - (x_coordinate * x_coordinate));

            marbles[i].transform.position = new Vector2(x_coordinate, y_coordinate + 0.6875f);
        }
    }

    public void CreateMarble()
    {
        if (max_create_marble > 0)
        {
            max_create_marble--;
            left_marble_number.text = "X" + max_create_marble;
            Instantiate(playmarble_prefab, new Vector2(0, -2.5f), Quaternion.identity);
        }
    }
}
