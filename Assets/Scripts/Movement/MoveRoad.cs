using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public GameObject car;
    int flag = 0;
    
    
    void Update()
    {
        if (flag == 1)
        {
            Destroy(gameObject);
        }
        if (((car.transform.position.x - gameObject.transform.position.x)  > 23.0f) && flag == 0)
        {
            
            Instantiate(gameObject, new Vector3(gameObject.transform.position.x + 42.5f, gameObject.transform.position.y, 1.0f), Quaternion.identity);
            flag = 1;
            
        }
    }
}
