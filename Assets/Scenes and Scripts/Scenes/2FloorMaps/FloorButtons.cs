// FloorSceneButtonHandler.cs
using UnityEngine;
using UnityEngine.UI;

public class FloorSceneButtonHandler : MonoBehaviour
{
    public static string buttonFloor;

    public string buttonName;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        buttonFloor = buttonName;
    }
}
