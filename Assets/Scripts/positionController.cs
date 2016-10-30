using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class positionController : MonoBehaviour {

    public GameObject clou;
    private bool win = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (clou.transform.position.y <= 0)
        {
            win = true;
            Debug.Log(win);
        }
    }
}
