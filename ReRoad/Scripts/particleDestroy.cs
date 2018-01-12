using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("remove", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void remove()
    {
        Destroy(gameObject);
    }
}
