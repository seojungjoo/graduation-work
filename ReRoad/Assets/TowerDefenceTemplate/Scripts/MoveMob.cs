using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMob : MonoBehaviour {

    public GameObject pathGo;

    int nodeIndex = 0;
    Transform targetNode;

    public GameObject me;
    int speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (targetNode == null)
        {
            Debug.Log(nodeIndex);
            getNextNode();
            if (targetNode == null)
            {
                Destroy(gameObject);
                // 다 옴 
            }
        }

        Vector3 dir = targetNode.position - transform.position;

        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
            targetNode = null;
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    void getNextNode()
    {
       
        targetNode = pathGo.transform.GetChild(nodeIndex);
        nodeIndex++;

        if (pathGo.transform.GetChild(nodeIndex) == null)
        {
            targetNode = me.transform;
            nodeIndex--;
        }
    }
}
