using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    // Loads the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Opens the setting element
    public void SettingsMenu()
    {
        Debug.Log("Settings Open"); // not finished just placeholder
    }

    // Opens the credit documentation
    public void Credits()
    {
        Application.OpenURL(
            "https://docs.google.com/document/d/1coMlAxxjbDOvlydSLe1Yh9Oe8ep3FJdbljDSe_B0rOk/edit"
        );
    }

    // Quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
