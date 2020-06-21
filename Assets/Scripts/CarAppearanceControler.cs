using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAppearanceControler : MonoBehaviour
{
    SpriteRenderer carSR;

    SpriteRenderer frontWheelSR;

    SpriteRenderer rearWheelSR;

    int clrCar;

    int clrWheels;


    public void getData()
    {
        carSR = gameObject.GetComponent<SpriteRenderer>();
        frontWheelSR = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        rearWheelSR = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (gameObject.name == "Car")
        {
            clrCar = GameData.playerCarColor;
            clrWheels = GameData.playerWheelsColor;
        }
        if (gameObject.name == "CarBot")
        {
            clrCar = GameData.botCarColor;
            clrWheels = GameData.botWheelsColor;
        }
    }

    private void Awake()
    {
        getData();
    }

    private void Start()
    {
        SetAllColors();
    }

    public void SetAllColors()
    {
        SetColorById(clrCar, carSR);
        SetColorById(clrWheels, frontWheelSR);
        SetColorById(clrWheels, rearWheelSR);
    }



    void SetColorById(int id, SpriteRenderer sprite)
    {
        
        switch (id)
        {
            case 0:
                sprite.color = Color.white;
                break;
            case 1:
                sprite.color = Color.black;
                break;
            case 2:
                sprite.color = Color.blue;
                break;
            case 3:
                sprite.color = Color.green;
                break;
            case 4:
                sprite.color = Color.yellow;
                break;
            case 5:
                sprite.color = Color.red;
                break;

            default:
                sprite.color = Color.white;
                break;
        }
    }
}
