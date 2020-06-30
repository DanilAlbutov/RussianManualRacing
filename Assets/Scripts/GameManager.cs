using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float h;

    public Car car;

    private static GameManager _instance;

    public bool flag = false;

    public static GameManager GetInstance() { return _instance; }

    private void Awake()
    {
        if (GameManager.GetInstance() == null)
            _instance = this;
        
        //Instantiate(Resources.Load("background"), new Vector3(0.0f, 10.0f, 1.0f), Quaternion.identity);   загрузка префабов
    }

    void Move()
    {
        if (!flag)
        {
            h = Input.GetAxis("Horizontal");
        } else
        {
            h = 1f;
        }
        car?.movement.MovementManager();

    }
    
    
    void Update()
    {
        Move();
    }
}
