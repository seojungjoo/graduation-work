using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMob : MonoBehaviour
{

    public GameObject pathGo;
    public GameObject item;

    int nodeIndex = 0;
    public Transform targetNode;

    public GameObject me;
    int speed = 10;

    Global_parameter gp;
    move nodeMaker;
    
    public GameObject blood;
    
    public int hp = 40;

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

    void OnTriggerEnter(Collider col)
    {
       
            if (col.tag == "deathTrigger")
            {
                Destroy(gameObject);
            }
            
    }

    void recvDmg(int dmg)
    {
        GameObject g = Instantiate(blood, transform.position, Quaternion.identity);
        g.SetActive(true);
        hp -= dmg;

        if (hp < 0)
        {
            //Global.GrayParts += 1;
            GameObject i = Instantiate(item);
            i.transform.position = this.transform.position;
            i.SetActive(true);

            float oneMore = Random.Range(.0f, 1.0f);

            if(oneMore < 0.2f)
            {
                i = Instantiate(item);
                i.transform.position = this.transform.position;
                i.SetActive(true);

            }

            oneMore = Random.Range(.0f, 1.0f);
            if(oneMore < 0.2f)
            {
                // 초록 템 드랍
            }
            Destroy(gameObject);
        }

        
    }

    
}
