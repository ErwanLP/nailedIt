using UnityEngine;
using System.Collections;
using System;

public class InputManager {

    public Movement m;
    public Action<Movement> callback;

    public InputManager(Action<Movement> callback)
    {
        this.callback = callback;
    }

    // Update is called once per frame
    public void getInput()
    {

        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, touch.position, touch.phase);
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Ended);
            }
        }
    }

    private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                this.m = new Movement(touchPosition);
                break;
            case TouchPhase.Ended:
                this.m.setFinalPosition(touchPosition);
                this.movementDone(this.m);
                break;
        }
    }

    private void movementDone(Movement m)
    {
        this.callback(m);
    }
}
