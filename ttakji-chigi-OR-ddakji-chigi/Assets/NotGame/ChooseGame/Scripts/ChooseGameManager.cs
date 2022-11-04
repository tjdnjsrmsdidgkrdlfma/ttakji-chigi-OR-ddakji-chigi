using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGameManager : MonoBehaviour
{
    public void FlowerButtonClicked()
    {
        SceneManager.LoadScene("Flower");
    }

    public void MarbleButtonClicked()
    {
        SceneManager.LoadScene("Marble");
    }

    public void RopeButtonClicked()
    {
        SceneManager.LoadScene("1v1");
    }

    public void TtakjiButtonClicked()
    {
        SceneManager.LoadScene("Ttakji");
    }

}
