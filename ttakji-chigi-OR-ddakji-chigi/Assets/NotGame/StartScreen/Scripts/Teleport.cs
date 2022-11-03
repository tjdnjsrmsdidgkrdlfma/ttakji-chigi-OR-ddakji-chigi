using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public void TeleportButtonClicked()
    {
        SceneManager.LoadScene("ChooseGame");
    }
}
