using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEngineMetr : MonoBehaviour
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
        transform.eulerAngles = new Vector3(0f, 0f, (getRp() * -300f));/* + (getRp() * -20f));*/ /*getRp() * 20;*/
    }

    float getRp()
    {
        return movement.rev;
    }
}
