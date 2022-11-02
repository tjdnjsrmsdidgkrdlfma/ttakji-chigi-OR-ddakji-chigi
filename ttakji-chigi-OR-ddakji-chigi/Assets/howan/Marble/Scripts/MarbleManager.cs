using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleManager : MonoBehaviour
{
    float max_create_marble;

    GameObject playmarble_prefab;

    void Awake()
    {
        max_create_marble = 2;

        playmarble_prefab = Resources.Load("Marble/PlayMarble") as GameObject;
    }

    public void CreateMarble()
    {
        if (max_create_marble > 0)
        {
            max_create_marble--;
            Instantiate(playmarble_prefab, new Vector2(0, -2.5f), Quaternion.identity);
        }
    }
}
