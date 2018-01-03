using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject me;

    public GameObject node;
    public GameObject Path;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("makeNode");
    }

    // Update is called once per frame
    void Update()
    {


        float xmove = Input.GetAxis("Horizontal");
        float zmove = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, xmove * 2.0f, 0.0f);

        transform.Translate(0.0f, 0.0f, zmove * 5 * Time.deltaTime);
        
    }

    IEnumerator makeNode()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            GameObject g = Instantiate(node, transform.position, Quaternion.identity);
            g.SetActive(true);
            g.transform.parent = Path.transform;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "EndTrigger")
        {
            me.SetActive(true);
            GameObject tr = GameObject.Find("Terrain");
            tr.GetComponent<terraiControl>().enabled = false;

            GameObject g = Instantiate(node, transform.position, Quaternion.identity);
            g.SetActive(true);
            g.transform.parent = Path.transform;

            StopCoroutine("makeNode");
            Destroy(gameObject);


            //Destroy(gameObject);
        }
    }
}
