using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject me;

    public GameObject node;
    public GameObject Path;

    Global_parameter gp;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("makeNode");
        gp = GameObject.FindObjectOfType<Global_parameter>();

        GameObject g = Instantiate(node, transform.position, Quaternion.identity);
        g.SetActive(true);
        g.transform.parent = Path.transform;
        gp.maxNodeNum++;
    }

    // Update is called once per frame
    void Update()
    {


        float xmove = Input.GetAxis("Horizontal");
        float zmove = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, xmove * 4.0f, 0.0f);

        transform.Translate(-zmove * 15 * Time.deltaTime, 0.0f,0.0f);
        
    }

    IEnumerator makeNode()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject g = Instantiate(node, transform.position, Quaternion.identity);
            g.SetActive(true);
            g.transform.parent = Path.transform;
            gp.maxNodeNum++;


        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "EndTrigger")
        {
            me.SetActive(true);

            GameObject tr = GameObject.Find("towerGround");
            tr.GetComponent<terraiControl>().enabled = false;

            GameObject g = Instantiate(node, transform.position, Quaternion.identity);
            g.SetActive(true);
            g.transform.parent = Path.transform;
            gp.maxNodeNum++;

            Debug.Log("Fuuuuuuuck !1");
            

            //StopCoroutine("makeNode");


            Destroy(gameObject);
        }
    }
}
