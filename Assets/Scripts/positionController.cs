using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class positionController : MonoBehaviour {

    public GameObject posClouGO;
    public GameObject posTableGO;
    public Text tEcart;
    public Text tWin;
    private bool win = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (posClouGO.transform.position.y <= posTableGO.transform.position.y)
        {
            win = true;
        }

        tEcart.text = ("Ecart : "+ (posClouGO.transform.position.y - posTableGO.transform.position.y));
        tWin.text = ("Win : " + win);
    }
}
