using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionControl : MonoBehaviour
{
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
            cursor.z = 0.0f;
            gameObject.transform.position = cursor;
        }
    }
}
