using UnityEngine;
using System.Collections;

public class inputManager : MonoBehaviour {

    public Movement m;
    public GameObject hammer;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
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
                this.m.log();
                this.movementDone(this.m);
                break;
        }
    }

    private void movementDone(Movement m)
    {
        hammer.GetComponent<mPhys>().boom(m);
    }
}
