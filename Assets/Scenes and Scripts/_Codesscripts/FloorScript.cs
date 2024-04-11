using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorScript : MonoBehaviour
{
    private Main_Menu menu;
    private void Return(){
        menu.MainMenu();
    }
    public void Diff_Selection(){
        SceneManager.LoadSceneAsync(3);
    }
}
