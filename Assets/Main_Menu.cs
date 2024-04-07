using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(2);
        }
    public void QuitGame() 
    { 
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
