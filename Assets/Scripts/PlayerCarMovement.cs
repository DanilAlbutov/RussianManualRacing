using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarMovement : Movement
{

    public Text txt;

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
        GuiOutput();

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

    void GuiOutput()
    {
        float printSpeed = localEngineSpeed + EngineSpeed(0.002f);
        txt.text = "Обороты: " + (EngineSpeed(0.002f) * 10000) + "\nСкорось: " + curSpeed + "\nПередача: " + curretShift;
    }

    
}
