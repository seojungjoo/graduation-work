﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMob : MonoBehaviour {

    public GameObject mob;

    int maxNum = 30;
    int currNum = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine("make");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator make()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject g = Instantiate(mob, transform.position,Quaternion.identity);
            g.SetActive(true);

            currNum += 1;

            if (currNum == maxNum)
                StopCoroutine("make");
        }
    }
}
