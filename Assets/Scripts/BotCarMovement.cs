using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarMovement : Movement
{
    // Start is called before the first frame update
    public void MovementManager()
    {
        base.MovementManager();
       
        BotControl();
        

    }

    void BotControl()
    {
        
        clutch = false;
        GearUp();
        clutch = true;
        hrznt = 1f;
    }

    private void Update()
    {
        MovementManager();
    }
}
