using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    GameObject bot;

    bool flag = true;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
        
    }

    void GetObjects()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            bot = GameObject.FindGameObjectsWithTag("Bot")[0];
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            flag = false;
        }
    }

    void SceneControl()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (flag)
                GetObjects();

            CheckPosition();
            
        }
    }

    void CheckPosition()
    {
        if (GameData.maxDistance <= player.transform.position.x)
        {
            GameData.lastGameResult = "you win";
            SceneManager.LoadScene("EndGame");
        }

        if (GameData.maxDistance <= bot.transform.position.x)
        {
            GameData.lastGameResult = "you lose";
            SceneManager.LoadScene("EndGame");
        }
    }

    private void FixedUpdate()
    {
        SceneControl();
    }



}
