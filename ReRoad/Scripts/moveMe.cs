using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMe : MonoBehaviour {

    bool grounded = true;
    Rigidbody rb;
    Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float xmove = Input.GetAxis("Horizontal");
        float zmove = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, xmove * 2.0f, 0.0f);

        transform.Translate(0.0f, 0.0f, zmove * 5 * Time.deltaTime);
        anim.SetFloat("speed", zmove);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded == true)
            {
                grounded = false;

                rb.AddForce(Vector3.up * 6.0f, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 8)
        {
            grounded = true;
        }
    }

    
}
