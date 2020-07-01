using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiOutput : MonoBehaviour
{
    Movement mv;
    public Slider sld;
    
    public Text txt = null;
    // Start is called before the first frame update
    void Start()
    {
        mv = gameObject.GetComponent<Movement>();
        sld.maxValue = GameData.maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        PrintCurretCarSetup();
        PrintCurretPos();       
    }

    void PrintCurretCarSetup()
    {
        //float printSpeed = mv.localEngineSpeed + mv.EngineSpeed(0.002f);
        int clvl = GameData.curLvl;
        txt.text =  mv.EngineSpeedData.Count + "";
    }

    void PrintCurretPos()
    {
        sld.value = mv.curretPos;
    }
}
