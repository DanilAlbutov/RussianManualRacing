using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int currentLevel = GameData.curLvl;
    public Movement mv;

    private void Start()
    {
        mv = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

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
        GameData.GetData();
        currentLevel++;
        GameData.tempSumValue += 0.001f;
        GameData.curLvl = currentLevel;        
        GameData.SetData();
    }

    public void GasPressed()
    {
        GameManager.GetInstance().flag = !GameManager.GetInstance().flag;
    }

    public void ClutchPressed()
    {
        mv.clutch = !mv.clutch;
    }

}
