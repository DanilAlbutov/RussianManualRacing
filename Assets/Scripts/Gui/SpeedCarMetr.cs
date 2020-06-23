using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCarMetr : MonoBehaviour
{
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.eulerAngles = new Vector3(0f, 0f, (getCurSpeed() * -80f));/* + (getRp() * -20f));*/ /*getRp() * 20;*/
    }

    float getCurSpeed()
    {
        return movement.curSpeed;
    }
}
