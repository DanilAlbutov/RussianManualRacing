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

    public void NextLvlPressed()
    {
        GameData.tempSumValue += 0.001f;
        GameData.curLvl += 1;
        BaseLvl lvl = new BaseLvl(GameData.curLvl);
        GameData.SetData();
    }

}
