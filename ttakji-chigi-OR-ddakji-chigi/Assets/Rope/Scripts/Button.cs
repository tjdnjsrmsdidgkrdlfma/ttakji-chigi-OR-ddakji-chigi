using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void _1v1ButtonClicked()
    {
        SceneManager.LoadScene("1v1");
    }

    public void _SoleButtonClicked()
    {
        SceneManager.LoadScene("Sole");
    }
}
