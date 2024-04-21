// DifficultySceneButtonHandler.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySceneButtonHandler : MonoBehaviour
{
    public string buttonName;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        string floorSceneButton = FloorSceneButtonHandler.buttonFloor;
        string combinedButton = floorSceneButton + " + " + buttonName;
        
        switch (combinedButton)
        {
            case "shadowed + easy":
                SceneManager.LoadSceneAsync(4);
                break;
            case "shadowed + intermediate":
                SceneManager.LoadSceneAsync(5);
                break;
            case "shadowed + nightmare":
                SceneManager.LoadSceneAsync(6);
                break;
            case "obsidian + easy":
                SceneManager.LoadSceneAsync(7);
                break;
            case "obsidian + intermediate":
                SceneManager.LoadSceneAsync(8);
                break;
            case "obsidian + nightmare":
                SceneManager.LoadSceneAsync(9);
                break;
            case "crimson + easy":
                SceneManager.LoadSceneAsync(10);
                break;
            case "crimson + intermediate":
                SceneManager.LoadSceneAsync(11);
                break;
            case "crimson + nightmare":
                SceneManager.LoadSceneAsync(12);
                break;
            default:
                Debug.LogError("Invalid combination: " + combinedButton);
                break;
        }
    }
}
