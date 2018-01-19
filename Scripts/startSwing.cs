using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSwing : MonoBehaviour {

    public beadtower bead;
    public Rigidbody rb;
    RigidbodyConstraints rbCon;
	// Use this for initialization
	void Start () {
        rbCon = rb.constraints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "car")
        {
            bead.enabled = true;
            rb.constraints = RigidbodyConstraints.None;
            Destroy(gameObject);
        }
    }
}
