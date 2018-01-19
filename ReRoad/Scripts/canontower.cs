using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canontower : MonoBehaviour
{

    public float AttackSpeed;
    public GameObject Bullet;
    bool FireOn = true;
    public Transform firePos;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            if(FireOn)
            {
                GameObject b = Instantiate(Bullet, firePos.position, transform.rotation);
                var canon = b.GetComponent<CanonBullet>();
                canon.targetpos = other.transform.position;
                FireOn = false;
                StartCoroutine(FireCheck());
            }
        }
    }

    IEnumerator FireCheck()
    {
        yield return new WaitForSeconds(AttackSpeed);
        FireOn = true;

    }


}
