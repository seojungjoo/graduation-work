using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironTower : MonoBehaviour {

    int dmg = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void giveDmg(Transform target)
    {
        target.SendMessage("recvDmg", dmg);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 11)
        {
            giveDmg(col.transform);
            
        }
    }
}
