using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public GameObject car;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int flag = 0;
    // Update is called once per frame
    void Update()
    {
        if (flag == 1)
        {
            Destroy(gameObject);
        }
        if (((car.transform.position.x - gameObject.transform.position.x)  > 20.0f) && flag == 0)
        {
            
            Instantiate(gameObject, new Vector3(car.transform.position.x + 10.0f, gameObject.transform.position.y, 1.0f), Quaternion.identity);
            flag = 1;
            
        }
    }
}
