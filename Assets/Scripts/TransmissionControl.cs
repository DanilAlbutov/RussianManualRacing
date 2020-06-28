using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionControl : MonoBehaviour
{
    public Vector3 displayPos;
    public int curShift = 0;
    public GameObject car;
    Movement mv;
    bool mouseDown;
    // Start is called before the first frame update
    void Start()
    {
        mv = car.GetComponent<Movement>();
        mouseDown = false;
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSelector();
    }

    void MoveSelector()
    {
        if (true)
        {
            
            // ограничить ход
            Vector3 cursor = Input.mousePosition;
            cursor = Camera.main.ScreenToWorldPoint(cursor);
            displayPos = cursor;
            cursor.z = 0.0f;


            CheckTransmissionPos(cursor);
            
        }

        void CheckTransmissionPos(Vector3 mousePos)
        {
            //
            
            switch (curShift)
            {
                case 0:
                    if (mousePos.x < 14f && mousePos.y > -6.5f)
                    {
                        gameObject.transform.position = new Vector3(14f, -6.5f, gameObject.transform.position.z);
                        curShift = 1;
                    }
                    if (mousePos.x < 14f && mousePos.y < -9f)
                    {
                        gameObject.transform.position = new Vector3(14f, -9f, gameObject.transform.position.z);
                        curShift = 2;
                    }
                    if (mousePos.y > -6.5f)
                    {
                        gameObject.transform.position = new Vector3(15.5f, -6.5f, gameObject.transform.position.z);
                        curShift = 3;
                    }
                    if (mousePos.y < -9f)
                    {
                        gameObject.transform.position = new Vector3(15.5f, -9f, gameObject.transform.position.z);
                        curShift = 4;
                    }

                    break;
                case 1:
                    if (mousePos.x > 15.5f && mousePos.y < -8f)
                    {
                        gameObject.transform.position = new Vector3(15.5f, -8f, gameObject.transform.position.z);
                        curShift = 0;
                    }
                    if (mousePos.y < -9f)
                    {
                        gameObject.transform.position = new Vector3(14f, -9f, gameObject.transform.position.z);
                        curShift = 2;
                    }
                    break;
                case 2:
                    if (mousePos.x > 15.5f && mousePos.y > -8f)
                    {
                        gameObject.transform.position = new Vector3(15.5f, -8f, gameObject.transform.position.z);
                        curShift = 0;
                    }
                    if (mousePos.y > -6.5f)
                    {
                        gameObject.transform.position = new Vector3(14f, -6.5f, gameObject.transform.position.z);
                        curShift = 1;
                    }
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    
                    break;
                default:
                    
                    break;
            }
        }
        
    }
}
