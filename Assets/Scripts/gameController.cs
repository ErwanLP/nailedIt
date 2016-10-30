using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    public int numberPlayer = 1;
    public Hammer hammer;
    public InputManager im;


	// Use this for initialization
	void Start () {
            this.hammer =  new Hammer();
            this.im = new InputManager(handleInputManager);
    }

    private void handleInputManager(Movement m)
    {
        this.hammer.getGameObject().GetComponent<mPhys>().boom(m);
    }

    // Update is called once per frame
    void Update () {
        this.im.getInput();

    }

}
