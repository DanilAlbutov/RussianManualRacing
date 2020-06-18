using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    public PlayerCarMovement movement;
    
    void Start()
    {
        
        movement = GetComponent<PlayerCarMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
