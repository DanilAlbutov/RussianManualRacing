using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionControl : MonoBehaviour
{
    public Vector3 displayPos;
    public Vector3 firstPos;
    public int curShift = 0;
    public int lastShift = 0;
    public GameObject selector_background;
    public GameObject car;
    Movement mv;
    bool[] repeatFlags = {false, false, false, false, false };
    

    void Start()
    {
        mv = car.GetComponent<Movement>();
        
        
    }

    void Update()
    {
        firstPos = selector_background.transform.position;
        MoveSelector();
    }

    void MoveSelector()
    {
        Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        displayPos = cursor;
        if (!mv.clutch)
        {
            CheckTransmissionPos(cursor);
        }
    }

    void CheckTransmissionPos(Vector3 mousePos)
    {
        
        if (mousePos.x > firstPos.x - 1.5f && mousePos.y < firstPos.y + 1.5f && mousePos.x < firstPos.x + 1.5f && mousePos.y > firstPos.y - 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x, firstPos.y, gameObject.transform.position.z);

            curShift = 0;
        }
        if (mousePos.x < firstPos.x - 1.5f && mousePos.y > firstPos.y + 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x - 1.5f, firstPos.y + 1.5f, gameObject.transform.position.z);
            CheckShiftUp(1);
        }
        if (mousePos.x < firstPos.x - 1.5f && mousePos.y < firstPos.y - 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x - 1.5f, firstPos.y - 1.5f, gameObject.transform.position.z);
            CheckShiftUp(2);
        }
        if (mousePos.x > firstPos.x - 1.5f && mousePos.x < firstPos.x + 1.5f && mousePos.y > firstPos.y + 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x, firstPos.y + 1.5f, gameObject.transform.position.z);
            CheckShiftUp(3);
        }
        if (mousePos.x > firstPos.x - 1.5f && mousePos.x < firstPos.x + 1.5f && mousePos.y < firstPos.y - 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x, firstPos.y - 1.5f, gameObject.transform.position.z);
            CheckShiftUp(4);
        }
        if (mousePos.x > firstPos.x + 1.5f && mousePos.y > firstPos.y + 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x + 1.5f, firstPos.y + 1.5f, gameObject.transform.position.z);
            CheckShiftUp(5);
        }
        if (mousePos.x < firstPos.x - 1.5f && mousePos.y < firstPos.y + 1.5f && mousePos.y > firstPos.y - 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x - 1.5f, firstPos.y, gameObject.transform.position.z);
        }
        if (mousePos.x > firstPos.x + 1.5f && mousePos.y < firstPos.y + 1.5f && mousePos.y > firstPos.y - 1.5f)
        {
            gameObject.transform.position = new Vector3(firstPos.x + 1.5f, firstPos.y, gameObject.transform.position.z);
        }


    }
    void CheckShiftUp(int value)
    {
        
        if (!repeatFlags[value - 1])
            mv.GearUp();
        repeatFlags[value - 1] = true;
    }
}
