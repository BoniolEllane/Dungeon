using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty_Sel : MonoBehaviour
{ 
    private Main_Menu menu;
    public void Easy(){
        SceneManager.LoadSceneAsync(7);
    }
    private void Return(){
        menu.FloorScript();
    }
}
