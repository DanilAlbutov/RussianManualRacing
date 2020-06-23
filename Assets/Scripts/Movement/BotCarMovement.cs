using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotCarMovement : Movement
{
    // Start is called before the first frame update
    
    private void Start()
    {
        enginePower = GameData.botCarPower;
        maxEngineSpeed = GameData.botMaxEngineRp;
        clutch = false;
        GearUp();
        clutch = true;
        hrznt = 1f;
    }
    public void MovementManager()
    {
        base.MovementManager();
       
        BotControl();
        

    }

    void BotControl()
    {
        
            if (EngineSpeed(enginePower) > maxEngineSpeed - 0.01f)
            {
                hrznt = 0f;
                new WaitForSeconds(5);
                
                clutch = false;
                GearUp();
                clutch = true;
                hrznt = 1f;
            }
    }

    private void Update()
    {
        MovementManager();
    }
}
