using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void StartGame()
    {
        LoadingManager.Instance.ChangeScene("MainScene");
    }

    void Quit()
    {
        Application.Quit();
    }

    void MoveToOptions()
    {

    }
}
