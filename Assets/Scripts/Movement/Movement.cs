using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    

    
    public bool clutch = true;
    public bool shiftDownFlag = false;
    public bool brakeFlag = false;

    float temp = 0f;

    public float enginePower = 0f;
    public float curretPos = 0f;
    public float maxEngineSpeed = 0f;
    public float maxRp = 0f;
    public float localEngineSpeed = 0f;
    public float curSpeed = 0.0f;
    public float hrznt = 0.0f;
    public float rev = 0.0f;
    public float accelValue = 0.00015f;

    public List<float> EngineSpeedData;   

    public int curretShift = 0;   
    
    private void Start()
    {
        EngineSpeedData.Add(0.05f);
    }

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
            DecreaseSpeed(0.01f); //curSpeed -= 0.01f;
        }
        
        if (clutch && EngineSpeedData.Count  != 0)
        {
            curSpeed = localEngineSpeed + EngineSpeed(enginePower);
        }
        if (!clutch || EngineSpeedData.Count  == 0)
        {
            DecreaseSpeed(0.00005f); //curSpeed = curSpeed - 0.00005f;
        }
            
       
    }

    void DecreaseSpeed(float factor)
    {
        if (curSpeed - factor < 0)
        {
            curSpeed = 0.0f;
            return;
        }
        curSpeed -= factor;
    }

    public void GearUp()
    {
        if (EngineSpeedData.Count < 5)
        {
            EngineSpeedData.Add(EngineSpeed(enginePower));
            localEngineSpeed += EngineSpeed(enginePower);
            rev = 0.05f;
            enginePower += accelValue;
        }
    }

    public void GearDown()
    {
        if (EngineSpeedData.Count - 1 >= 0)
        {
            temp = localEngineSpeed - EngineSpeedData[EngineSpeedData.Count - 1];
            shiftDownFlag = true;
            rev = EngineSpeedData[EngineSpeedData.Count - 1];
            EngineSpeedData.RemoveAt(EngineSpeedData.Count - 1);
            enginePower -= accelValue;
        }

    }

}
