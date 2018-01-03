using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMob : MonoBehaviour
{

    public GameObject pathGo;

    int nodeIndex = 0;
    public Transform targetNode;

    public GameObject me;
    int speed = 6;

    Global_parameter gp;
    move nodeMaker;
    // Use this for initialization
    void Start()
    {
        nodeMaker = GameObject.FindObjectOfType<move>();
        gp = GameObject.FindObjectOfType<Global_parameter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetNode == null)
        {
            getNextNode();

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
        Debug.Log("Max : " + gp.maxNodeNum);

        Debug.Log("Curr : " + nodeIndex);

        if (nodeIndex < gp.maxNodeNum)
        {
            targetNode = pathGo.transform.GetChild(nodeIndex);

            nodeIndex++;
            return;
        }
        else
        {
            targetNode = me.transform;
            return;
        }
    }
}
