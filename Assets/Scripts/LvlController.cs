using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    public float timeToStart = 3.0f;

    bool flag = true;

    void Start()
    {
        GameData.GetData();
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
            {
                
                GetObjects();
                
            }
                
            if (player != null)
                CheckPosition();            
        }
        if(SceneManager.GetActiveScene().name == "EndGame" )
        {
            ResetData();
            GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = GameData.lastGameResult;
            
        }
    }

    void CheckPosition()
    {
        if (GameData.maxDistance <= player?.transform.position.x)
        {
            GameData.lastGameResult = "win";
            SceneManager.LoadScene("EndGame");
            
        }

        if (GameData.maxDistance <= bot?.transform.position.x)
        {
            GameData.lastGameResult = "lose";
            SceneManager.LoadScene("EndGame");
        }
    }

    void ResetData()
    {
        timeToStart = 3.0f;
        flag = true;
    }

    void StartControler()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            timeToStart -= Time.deltaTime;
            
            if (timeToStart < 5)
            {
                GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = "";
            }
            if (timeToStart > 0 && player != null)
            {
                bot.GetComponent<Movement>().curSpeed = 0.0f;
                player.GetComponent<Movement>().curSpeed = 0.0f;
                GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = ((int)timeToStart) + 1 + "";
            }
            
        }
    }

    private void Update()
    {
        StartControler();
    }
    
    private void FixedUpdate()
    {
        SceneControl();
    }



}
