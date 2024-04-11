using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty_Sel : MonoBehaviour
{
    public void Easy(){
        SceneManager.LoadSceneAsync(7);
    }
}
