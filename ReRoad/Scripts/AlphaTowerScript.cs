using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTowerScript : MonoBehaviour
{
    GameObject j;
	void Start()
    {
        j = GameObject.Find("JAne");
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="tower")
        {

            j.GetComponent<CreateDeleteTower>().isCollision = true;

        }
        
    }
    void OnTriggerExit()
    {
        //Debug.Log("트리거나가리");
        j.GetComponent<CreateDeleteTower>().isCollision = false;
    }
}
