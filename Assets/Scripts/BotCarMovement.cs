using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarMovement : Movement
{
    // Start is called before the first frame update
    public float gt = 0f;
    private void Start()
    {
        enginePower = 0.002f;
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
        gt = EngineSpeed(enginePower);
            if (EngineSpeed(enginePower) > 0.59)
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
