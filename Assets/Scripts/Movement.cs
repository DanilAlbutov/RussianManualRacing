using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Car car;

    public Text txt;

    float curretSpeed = 0.0f;

    public float curretGear = 0f;

    int curretShift = 0;

    float hrznt = 0.0f;

    float rev = 0.0f;

    public void Init(Car cr)
    {
        car = cr;
    }

    public void MovementManager()
    {
        hrznt = GameManager.GetInstance().h;
        
        
        Acceleration(curretGear);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GearUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GearDown();
        }


        // придумать как вывести текущую скорость и как тормозить

        curretSpeed = EngineSpeed() * curretGear;
        txt.text = "Обороты: " + (EngineSpeed()  * 10000) + " Скорось: " + curretSpeed + "Передача: " + curretShift;
    }

    public float EngineSpeed()
    {
        
        if (Math.Abs(hrznt) > 0)
        {
            while (rev < 0.6f)
            {
                rev += 0.005f;
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
                rev = rev - 0.005f;
                return rev;
            }
        }
        return rev;
    }

    void Acceleration(float gear)
    {
        transform.position = new Vector3(transform.position.x + EngineSpeed() * gear, transform.position.y, transform.position.z);
    }

    void RecursiveTransmission(int Shift)
    {

    }

    void GearUp()
    {
        if (curretGear == 0f)
        {
            curretGear = 1f;
            curretShift++;
        }
        else
        {
            if (curretGear + 0.5f <= 3f)
            {
                curretGear += 0.5f;
                curretShift++;
            }
        }
    }

    void GearDown()
    {
        if (curretGear == 1f)
        {
            curretGear = 0f;
            curretShift--;
        }
        else
        {
            if (curretGear - 0.5f >= 1)
            {
                curretGear -= 0.5f;
                curretShift--;
            }
        }
        
    }
}
