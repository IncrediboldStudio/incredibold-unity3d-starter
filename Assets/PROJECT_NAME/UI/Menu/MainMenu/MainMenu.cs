using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> submenus;
    [SerializeField] UIDocument uiDocument;

    private VisualElement root;

    public void Start()
    {
        root = uiDocument.rootVisualElement;

        var button = root.Q<Button>("Play");
        button.RegisterCallback<ClickEvent>(StartGame);
    }

    private void StartGame(ClickEvent evt = null)
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
