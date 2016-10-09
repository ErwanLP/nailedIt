using UnityEngine;
using System.Collections;

public class cPhys : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = 30;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
