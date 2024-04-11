using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorScript : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Diff_Selection(){
        SceneManager.LoadSceneAsync(3);
    }
}
