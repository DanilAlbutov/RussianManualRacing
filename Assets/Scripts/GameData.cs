using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData 
{
    public static float playerCarPower = 0.002f;

    public static float playerMaxEngineRp = 0.6f;

    public static int playerCarColor = 3;

    public static int playerWheelsColor = 0;


    public static float botCarPower = 0.0017f;

    public static float botMaxEngineRp = 0.5f;

    public static int botCarColor = 4;

    public static int botWheelsColor = 4;


    public static float maxDistance = 500.0f;

    public static string lastGameResult = "win";

    
    
    public static void SetData()
    {
        PlayerPrefs.SetFloat("curPlayerCarPower", playerCarPower);
        PlayerPrefs.SetFloat("curPlayerMaxEngineRp", playerMaxEngineRp);
        PlayerPrefs.SetInt("curPlayerCarColor", playerCarColor);
        PlayerPrefs.SetInt("curPlayerWheelsColor", playerWheelsColor);
        PlayerPrefs.Save();
    }

    public static void GetData()
    {
        playerCarPower = PlayerPrefs.GetFloat("curPlayerCarPower");
        playerMaxEngineRp = PlayerPrefs.GetFloat("curPlayerMaxEngineRp");
        playerCarColor = PlayerPrefs.GetInt("curPlayerCarColor");
        playerWheelsColor = PlayerPrefs.GetInt("curPlayerWheelsColor");
    }
    // Start is called before the first frame update

}
