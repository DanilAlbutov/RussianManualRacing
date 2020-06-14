using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Car car;

    public Text txt;

    float hrznt = 0.0f;
    float rev = 0.0f;
    public void Init(Car cr)
    {
        car = cr;
    }

    public void Accelerate()
    {
        hrznt = GameManager.GetInstance().h;
        //car.rb.AddForce(transform.right * 10.0f * hrznt, ForceMode2D.Force);
        car.rb.AddForce(transform.right * EngineSpeed() / 2, ForceMode2D.Force);
        txt.text = "Обороты: " + (EngineSpeed()  * 1000) + " Скорось: " + (transform.right * EngineSpeed() / 2);
    }

    public float EngineSpeed()
    {
        
        if (Math.Abs(hrznt) > 0)
        {
            while (rev < 6.0f)
            {
                rev += 0.01f;
                return rev;
            }
        }
        else
        {
            while (rev > 0.0f)
            {
                rev = -0.1f;
                return rev;
            }
        }
        return rev;
    }
}
