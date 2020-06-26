using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class WheelRotation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent.GetComponent<Movement>().curSpeed > 0.05f && transform.parent.GetComponent<Movement>().transform.position.x > 0.01)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}
