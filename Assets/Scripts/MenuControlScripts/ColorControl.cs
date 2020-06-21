using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class ColorControl : MonoBehaviour
{
    int selectMode = 0;

    public GameObject car;

    CarAppearanceControler ac;

    public Text text;

    int curColor = 0;

    private void Start()
    {
        ac = car.GetComponent<CarAppearanceControler>();
    
    }

    public void selectCarColorMode()
    {
        text.text = "Change car color";
        UpdateColor();
        selectMode = 0;
    }

    public void selectWheelColorMode()
    {
        text.text = "Change wheels color";
        UpdateColor();
        selectMode = 1;
    }

    private void UpdateColor()
    {
        if (selectMode == 0)
        {
            GameData.playerCarColor = curColor;
        }
        if (selectMode == 1)
        {
            GameData.playerWheelsColor = curColor;
        }
        GameData.SetData();
        ac.getData();
        ac.SetAllColors();
    }

    public void SelectWhiteColor()
    {
        curColor = 0;
        UpdateColor();
    }

    public void SelectBlackColor()
    {
        curColor = 1;
        UpdateColor();
    }

    public void SelectBlueColor()
    {
        curColor = 2;
        UpdateColor();
    }

    public void SelectGreenColor()
    {
        curColor = 3;
        UpdateColor();
    }

    public void SelectYellowColor()
    {
        curColor = 4;
        UpdateColor();
    }

    public void SelectRedColor()
    {
        curColor = 5;
        UpdateColor();
    }

    public void onBackPressed()
    {
        UpdateColor();
    }

}
