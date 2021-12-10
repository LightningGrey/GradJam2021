using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Test Level 2");
    }

    public void OnInstructionsButton()
    {
        instructionsPanel.SetActive(true);
    }

    public void OnInstructionsCloseButton()
    {
        instructionsPanel.SetActive(false);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
