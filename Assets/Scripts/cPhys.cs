using UnityEngine;
using System.Collections;

public class cPhys : MonoBehaviour {

    public Rigidbody rb;
    public int res;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = res;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
