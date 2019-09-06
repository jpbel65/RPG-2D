using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//jeu en pause  activation du UI de l'inventaire
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(GameIsPaused) //resume
            {
                PauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;
            }
            else // pause
            {
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }
    }

    public void Save()
    {
        Debug.Log("SAVE");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
