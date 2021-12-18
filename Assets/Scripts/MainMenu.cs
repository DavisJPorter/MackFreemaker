using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
    //Loads the next scene in the que
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quits Game
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void Settings()
    {

    }
}
