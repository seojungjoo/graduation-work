using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static int GreenParts;
    public static int GrayParts;
}

public class Global_parameter : MonoBehaviour
{

    public int maxNodeNum = 0;
    // Use this for initialization
    void Start()
    {
        maxNodeNum = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
