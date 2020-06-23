using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    

    float temp = 0f;

    public bool shiftDownFlag = false;

    public bool brakeFlag = false;

    public float enginePower = 0f;

    public float curretPos = 0f;

    public float maxEngineSpeed = 0f;

    public float maxRp = 0f;

    float[] engineSpeedData = new float[6];    

    public float localEngineSpeed = 0f;

    public int curretShift = 0;

    public float curSpeed = 0f;

    public bool clutch = true;

    public float hrznt = 0.0f;

    public float rev = 0.0f;

    public void MovementManager()
    {
        

        Acceleration(); //ускорение автомобиля

        SpeedControl(); // конотроль скорости автомобиля и обработка сцепления

    }

    public float EngineSpeed(float power)
    {
        
        if (Math.Abs(hrznt) > 0f)
        {
            while (rev < maxEngineSpeed)
            {
                rev += power;
                return rev;
            }
        }
        else
        {
            while (true)
            {
                if (rev < 0.05f)
                {
                    break;
                }
                rev = rev - power;
                return rev;
            }
        }
        return rev;
    }

    public void Acceleration()
    {
        curretPos = gameObject.transform.position.x;
        transform.position = new Vector3(transform.position.x + curSpeed, transform.position.y, transform.position.z);
        
        
    }

    public void SpeedControl()
    {
        if (shiftDownFlag)
        {
            localEngineSpeed -= 0.005f;
            if (localEngineSpeed <= temp)
                shiftDownFlag = false;
        }
        if (brakeFlag)
        {
            curSpeed -= 0.01f;
        }
        if (curSpeed < 0)
        {
            curSpeed = 0.0f;
        }
        if (clutch && curretShift != 0)
        {
            curSpeed = localEngineSpeed + EngineSpeed(enginePower);
        }
        if (!clutch || curretShift == 0)
        {
            curSpeed = curSpeed - 0.00005f;
        }
            
       
    }

    public void GearUp()
    {
        if (curretShift != 0) { 
            if (curretShift + 1 <= 5 )
            {
                curretShift++;
                engineSpeedData[curretShift] = EngineSpeed(enginePower);
                localEngineSpeed += EngineSpeed(enginePower);
                rev = 0.05f;
            
            }
        } else
        {
            curretShift++;
        }
        
    }

    public void GearDown()
    {
        if (curretShift - 1 >= 0)
        {
            curretShift--;
            temp = localEngineSpeed - engineSpeedData[curretShift];
            
            shiftDownFlag = true;
            rev = engineSpeedData[curretShift];
            engineSpeedData[curretShift] = 0f;
        }
        
    }

}
