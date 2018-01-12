using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UIsc : MonoBehaviour
{

    public GUIStyle GreenParts;
    public GUIStyle GrayParts;

    int Green;
    int Gray;
    // Use this for initialization
    void Start()
    {
        Green = 5;
        Gray = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Box(new Rect(20.0f, 10.0f, 56.0f, 56.0f), ": " + Green.ToString(), GreenParts);
        GUI.Box(new Rect(176.0f, 10.0f, 56.0f, 56.0f), ": " + Gray.ToString(), GrayParts);

    }
}