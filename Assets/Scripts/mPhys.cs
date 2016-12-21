using UnityEngine;
using System.Collections;

public class mPhys : MonoBehaviour {

    public Rigidbody rb;
    [Range(0, 10)]
    public int speedtoForce;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.drag = 2;
	}
    
    public void boom (Movement m)
    {
        float force = m.getYSpeed() * speedtoForce;
        rb.AddForce(transform.right * -force);
    }
}
