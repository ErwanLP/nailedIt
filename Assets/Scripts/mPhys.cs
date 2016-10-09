using UnityEngine;
using System.Collections;

public class mPhys : MonoBehaviour {

    private float force;
    public Rigidbody rb;
    [Range(0, 10)]
    public int speedtoForce;

    public static float speed
    {
        get { return speed; }
    }

    // Use this for initialization
    void Start () {

        force = speed * speedtoForce;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * -force);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
