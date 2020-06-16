using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float h;

    public Car car;

    

    private static GameManager _instance;

    public static GameManager GetInstance() { return _instance; }

    private void Awake()
    {
        if (GameManager.GetInstance() == null)
            _instance = this;
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        car?.movement.MovementManager();

        
        

        
    }
    
    
    void Update()
    {
        Move();

    }
}
