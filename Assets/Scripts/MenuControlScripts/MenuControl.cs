using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGamePressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void ImprovePressed()
    {
        SceneManager.LoadScene("Improve");
    }

    public void SetlvlPressed()
    {
        SceneManager.LoadScene("Setlvl");
    }

    public void BackPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
