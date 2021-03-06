﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLvl 
{
    float botCarPower = GameData.botCarPower;
    float botCarMaxEngineRp = GameData.botMaxEngineRp;
    int botCarColor = GameData.botCarColor;
    int botWheelsColor = GameData.botWheelsColor;

    float rewardForVictory = GameData.lastRewardForVictory;

    float rewardForLose = GameData.lastRewardForLose;

    float maxDistance = GameData.maxDistance;

    public BaseLvl(int curLevel)
    {
        float valueSum = curLevel * 0.00001f ;
        float distance = (curLevel / (curLevel + 1)) * 1700.0f;
        botCarPower += valueSum;
        if (botCarMaxEngineRp <= 0.6)
            botCarMaxEngineRp += (valueSum * 10f);
        else
            botCarMaxEngineRp = 0.52f;
        if (botCarColor >= 5)
        {
            botCarColor = 0;
        }
        else
        {
            botCarColor++;
        }
        if (botCarColor >= 5)
        {
            botWheelsColor = 0;
        }
        else
        {
            botWheelsColor++;
        }
        rewardForLose *= 1.1f;
        rewardForVictory *= 1.15f;
        maxDistance = distance;
        SetData();
    }

    void SetData()
    {
        GameData.botCarPower = botCarPower;
        GameData.botMaxEngineRp = botCarMaxEngineRp;
        GameData.botCarColor = botCarColor;
        GameData.botWheelsColor = botWheelsColor;
        GameData.lastRewardForVictory = rewardForVictory ;
        GameData.lastRewardForLose = rewardForLose;
        GameData.maxDistance = maxDistance;
        GameData.SetData();
    }
}
