using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beadtower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.rotation.x >= 0.5f)
            GetComponent<HingeJoint>().axis = new Vector3(-1, 0, 0);
        else if (this.transform.rotation.x <= -0.5f)
            GetComponent<HingeJoint>().axis = new Vector3(1, 0, 0);
        //   this.transform.Rotate(new Vector3(1, 0, 0));
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10000));
	}
}
