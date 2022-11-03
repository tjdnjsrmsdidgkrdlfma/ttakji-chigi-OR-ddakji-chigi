using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(486, 1080, true);
    }

    public void TeleportButtonClicked()
    {
        SceneManager.LoadScene("ChooseGame");
    }
}
