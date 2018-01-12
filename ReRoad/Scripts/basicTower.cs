using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicTower : MonoBehaviour
{

    public Transform body;
    public Transform head;

    MoveMob[] enemies;

    public Transform target;

    public Transform gunPos1;
    public Transform gunPos2;

    public Transform ptc1;
    public Transform ptc2;

    public int range = 10;


    int dmg = 1;

    float fireCoolDown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            ptc1.gameObject.SetActive(false);
            ptc2.gameObject.SetActive(false);

            StopCoroutine("shoot");

            getNewTarget();
        }
        else if (Vector3.Distance(target.transform.position, transform.position) < range)
        {
            //Quaternion modify = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            Vector3 dir = target.transform.position - transform.position;
            Quaternion headRot = Quaternion.LookRotation(dir, transform.up);

            ptc1.gameObject.SetActive(true);
            ptc2.gameObject.SetActive(true);
            body.rotation = Quaternion.Lerp(body.rotation, headRot, 0.3f);
            //

        }
        else
        {
            ptc1.gameObject.SetActive(false);
            ptc2.gameObject.SetActive(false);

            StopCoroutine("shoot");
            target = null;
        }
    }

    void getNewTarget()
    {
        enemies = FindObjectsOfType<MoveMob>();

        float minDist = Mathf.Infinity;


        foreach (MoveMob e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);


            if (dist < range)
            {
                if (dist < minDist)
                {
                    minDist = dist;
                    target = e.transform;
                }
            }

        }
        if (target != null)
            StartCoroutine("shoot");
    }

    void giveDmg()
    {
        target.transform.SendMessage("recvDmg",dmg);
    }

    IEnumerator shoot()
    {
        while(true)
        {
            if(target)
                giveDmg();
            yield return new WaitForSeconds(0.5f);
        }

    }

}
