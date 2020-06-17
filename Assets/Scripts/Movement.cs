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

    public bool clutch = true;

    float hrznt = 0.0f;

    float rev = 0.0f;

    public void Init(Car cr)
    {
        car = cr;
    }

    public void MovementManager()
    {
        hrznt = GameManager.GetInstance().h;
        
        Acceleration();
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

        float printSpeed = localEngineSpeed + EngineSpeed(0.002f);
        txt.text = "Обороты: " + (EngineSpeed(0.002f) * 10000) + "\n Скорось: " + printSpeed + "\n Передача: " + curretShift;

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
        if (curretShift != 0) 
            transform.position = new Vector3(transform.position.x + (localEngineSpeed + EngineSpeed(0.002f))  , transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x + (localEngineSpeed), transform.position.y, transform.position.z);
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
        if (curretShift == 1)
        {
            curretShift--;
            brakeEngineSpeed();
        }
        else
        {
            if (curretShift - 1 >= 0)
            {

                curretShift--;
                brakeEngineSpeed();
                rev = engineSpeedData[curretShift];
            }
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
