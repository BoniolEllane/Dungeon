using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void FloorScript()
    {
        SceneManager.LoadSceneAsync(1);
        }
    public void QuitGame() 
    { 
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
