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

    float timeToStart = 3;

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
            {
                GetObjects();
                bot.GetComponent<Movement>().enginePower = 0.0f;
                bot.GetComponent<Movement>().accelValue = 0.0f;
            }
                
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

    void StartControler()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            timeToStart -= Time.deltaTime;
            if ( timeToStart <= 0 && ( timeToStart >= -4))
            {
                GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = "GO!";
            }
            if (timeToStart < 5)
            {
                GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = "";
            }
            if (timeToStart > 0)
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
