using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;

    public Movement movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        movement.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
