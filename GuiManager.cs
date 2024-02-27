using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    // starts the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // opens the settings menu
    public void SettingsMenu()
    {
        Debug.Log("Settings Open"); // not finished just placeholder
    }

    // opens the credit documentation
    public void Credits()
    {
        Application.OpenURL("https://docs.google.com/document/d/1coMlAxxjbDOvlydSLe1Yh9Oe8ep3FJdbljDSe_B0rOk/edit");
    }

    // quits the game
    public void Quit()
    {
        Application.Quit();
    }
}
