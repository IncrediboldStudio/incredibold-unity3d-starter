using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> submenus;

    public void StartGame()
    {
        LoadingManager.Instance.ChangeScene("MainScene");
    }

    public void OpenSubMenu(GameObject menuToOpen)
    {
        foreach (GameObject submenu in submenus)
        {
            submenu.SetActive(false);
        }
        menuToOpen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
