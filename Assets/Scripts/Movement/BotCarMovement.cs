using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotCarMovement : Movement
{
    // Start is called before the first frame update
    public float shiftUpDelay;

    private IEnumerator flagCoroutine;

    private void Awake()
    {
        
    }

    private void Start()
    {
        enginePower = GameData.botCarPower;
        maxEngineSpeed = GameData.botMaxEngineRp;
        shiftUpDelay = 1.5f; // задержка переключения бота
        
        
        clutch = false;
        GearUp();
        clutch = true;
        hrznt = 1f;
    }
    public void MovementManager()
    {
        base.MovementManager();
       
        BotControl();
        

    }

    IEnumerator Delay()
    {
        
        Debug.Log("Начало задержки");
        yield return new WaitForSeconds(shiftUpDelay);
        Debug.Log("Конец задержки");
        GearUp();
        flagCoroutine = null;
    }

    private void BotControl()
    {
        
        if (EngineSpeed(enginePower) > maxEngineSpeed - 0.01f)
        {
            hrznt = 0f;
            clutch = false;
            if (flagCoroutine == null)
            {
                flagCoroutine = Delay();
                StartCoroutine(flagCoroutine);
            }
            
            clutch = true;
            hrznt = 1f;

        }
    }

    private void Update()
    {
        MovementManager();
    }
}
