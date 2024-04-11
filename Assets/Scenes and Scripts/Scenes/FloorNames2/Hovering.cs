using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public GameObject textToDisplay;

    private void Start()
    {
        // Initially hide the text
        textToDisplay.SetActive(false);
    }

    public void OnPointerEnter()
    {
        // Show text when mouse enters the button
        textToDisplay.SetActive(true);
    }

    public void OnPointerExit()
    {
        // Hide text when mouse exits the button
        textToDisplay.SetActive(false);
    }
}
