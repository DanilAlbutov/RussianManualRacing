using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameData 
{
    //player
    public static float playerCarPower = 0.002f;
    public static float playerMaxEngineRp = 0.6f;
    public static int playerCarColor = 3;
    public static int playerWheelsColor = 0;

    //bot
    public static float botCarPower = 0.0017f;
    public static float botMaxEngineRp = 0.5f;
    public static int botCarColor = 4;
    public static int botWheelsColor = 4;
    public static float botDelay = 2.0f;

    //lvl settings
    public static float maxDistance = 500.0f;
    public static string lastGameResult = "win";
    public static float lastRewardForVictory = 0f;
    public static float lastRewardForLose = 0f;


    public static int curMoney = 0;

    public static int curLvl = 0;

    public static float tempSumValue = 0.001f;
    
    
    public static void SetData()
    {
        PlayerPrefs.SetFloat("curPlayerCarPower", playerCarPower);
        PlayerPrefs.SetFloat("curPlayerMaxEngineRp", playerMaxEngineRp);
        PlayerPrefs.SetInt("curPlayerCarColor", playerCarColor);
        PlayerPrefs.SetInt("curPlayerWheelsColor", playerWheelsColor);
        PlayerPrefs.SetInt("curMoney", curMoney);
        PlayerPrefs.SetInt("curLvl", curLvl);
        PlayerPrefs.SetFloat("tempSumValue", tempSumValue);
        PlayerPrefs.SetFloat("botDelay", botDelay);
        PlayerPrefs.Save();
    }

    public static void GetData()
    {
        playerCarPower = PlayerPrefs.GetFloat("curPlayerCarPower");
        playerMaxEngineRp = PlayerPrefs.GetFloat("curPlayerMaxEngineRp");
        playerCarColor = PlayerPrefs.GetInt("curPlayerCarColor");
        playerWheelsColor = PlayerPrefs.GetInt("curPlayerWheelsColor");
        curMoney = PlayerPrefs.GetInt("curMoney");
        curLvl = PlayerPrefs.GetInt("curLvl");
        tempSumValue = PlayerPrefs.GetFloat("tempSumValue");
        botDelay = PlayerPrefs.GetFloat("botDelay");
    }
    // Start is called before the first frame update

}
