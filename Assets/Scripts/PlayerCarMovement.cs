using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarMovement : Movement
{

    

    private void Start()
    {
        enginePower = 0.002f;
        maxEngineSpeed = 0.6f;
    }

    public void MovementManager()
    {
        base.MovementManager();
        hrznt = GameManager.GetInstance().h;
        KeyHandling();
        

    }

    void KeyHandling()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            brakeFlag = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            brakeFlag = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !clutch)
        {
            GearUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !clutch)
        {
            GearDown();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            clutch = false;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            clutch = true;
        }
    }

   

    
}
