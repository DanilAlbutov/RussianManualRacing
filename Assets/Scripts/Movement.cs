using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Car car;

    public Text txt;

    float[] engineSpeedData = new float[5];    

    float localEngineSpeed = 0f;

    int curretShift = 0;

    float curSpeed = 0f;

    public bool clutch = true;

    float hrznt = 0.0f;

    float rev = 0.0f;

    public void Init(Car cr)
    {
        car = cr;
    }

    void KeyHandling()
    {
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

    public void MovementManager()
    {
        hrznt = GameManager.GetInstance().h;
        
        Acceleration();

        KeyHandling();

        SpeedControl();

        GuiOutput();

        

    }

    void GuiOutput()
    {
        float printSpeed = localEngineSpeed + EngineSpeed(0.002f);
        txt.text = "Обороты: " + (EngineSpeed(0.002f) * 10000) + "\nСкорось: " + curSpeed + "\nПередача: " + curretShift;
    }

    public float EngineSpeed(float power)
    {
        
        if (Math.Abs(hrznt) > 0)
        {
            while (rev < 0.6f)
            {
                rev += power;
                return rev;
            }
        }
        else
        {
            while (true)
            {
                if (rev < 0.05)
                {
                    break;
                }
                rev = rev - power;
                return rev;
            }
        }
        return rev;
    }

    void Acceleration()
    {
        
         transform.position = new Vector3(transform.position.x + curSpeed, transform.position.y, transform.position.z);
        
        
    }

    void SpeedControl()
    {
        
        if (curSpeed < 0)
        {
            curSpeed += 0.05f;
        }
        if (clutch && curretShift != 0)
        {
            curSpeed = localEngineSpeed + EngineSpeed(0.002f);
        }
        if (!clutch)
        {
            curSpeed = curSpeed - 0.00005f;
        }
            
       
    }

    void GearUp()
    {
        if (curretShift + 1 <= 5 )
        {
            engineSpeedData[curretShift] = EngineSpeed(0.002f);
            localEngineSpeed += EngineSpeed(0.002f);
            rev = 0.05f;
            curretShift++;
        }
        
    }

    void GearDown()
    {
        if (curretShift - 1 >= 0)
        {
            curretShift--;
            localEngineSpeed = localEngineSpeed - engineSpeedData[curretShift];
                           
            rev = engineSpeedData[curretShift];
        }
        
    }

    //исправит: при понижении на нейтраль сбрасывает скорость на 0

    void brakeEngineSpeed()
    {
        float temp = localEngineSpeed - engineSpeedData[curretShift];
        while (localEngineSpeed > temp)
        {
            if (localEngineSpeed < 0)
            {
                localEngineSpeed = 0f;
                break;
            }
            
            localEngineSpeed = localEngineSpeed - 0.00002f;
        }
    }
}
