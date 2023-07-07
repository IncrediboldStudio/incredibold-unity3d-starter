using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateController : Singleton<LevelStateController>
{
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenuController pauseMenuController = pauseMenu.GetComponent<PauseMenuController>();

            if (!pauseMenuController.isOpen())
                pauseMenuController.OpenMenu();
            else
                pauseMenuController.CloseMenu();
        }
            

    }
}
