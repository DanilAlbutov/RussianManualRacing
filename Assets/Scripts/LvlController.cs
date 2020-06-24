using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    GameObject bot;

    bool flag = true;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if (GameObject.FindGameObjectsWithTag("LvlControl").Length > 1)
        {
            Destroy(gameObject);
        }
        
        
    }

    void GetObjects()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            bot = GameObject.FindGameObjectWithTag("Bot");
            player = GameObject.FindGameObjectWithTag("Player");
            flag = false;
        }
    }

    void SceneControl()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (flag)
                GetObjects();
            if (player != null)
                CheckPosition();            
        }
        if(SceneManager.GetActiveScene().name == "EndGame" )
        {
            GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = GameData.lastGameResult;
            
        }
    }

    void CheckPosition()
    {
        if (GameData.maxDistance <= player?.transform.position.x)
        {
            GameData.lastGameResult = "you win";
            SceneManager.LoadScene("EndGame");
            
        }

        if (GameData.maxDistance <= bot?.transform.position.x)
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
