using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : Singleton<PauseMenuController>
{
    [SerializeField] List<GameObject> submenus;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void OpenSubMenu(GameObject menuToOpen)
    {
        foreach (GameObject submenu in submenus)
        {
            submenu.SetActive(false);
        }
        menuToOpen.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        CloseMenu();
        LoadingManager.Instance.ChangeScene("MainMenu");
    }

    public bool isOpen()
    {
        return gameObject.activeSelf;
    }

}
