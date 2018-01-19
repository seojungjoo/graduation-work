using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class UIsc : MonoBehaviour
{

    public GUIStyle GreenParts;
    public GUIStyle GrayParts;

    public GUIStyle edgeGreenParts;
    public GUIStyle edgeGrayParts;

    // Use this for initialization
    void Start()
    {
        Global.GreenParts = 0;
        Global.GrayParts = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        // 테두리
        GUI.Box(new Rect(20.0f, 10.0f, 56.0f, 56.0f),  "<color=#ffffff>" + ": " + "</color>" + "<color=#ffffff>" + Global.GreenParts.ToString() + "</color>", edgeGreenParts);
        GUI.Box(new Rect(176.0f, 10.0f, 56.0f, 56.0f), "<color=#ffffff>" + ": " + "</color>" + "<color=#ffffff>" + Global.GrayParts.ToString() + "</color>", edgeGrayParts);

        GUI.Box(new Rect(20.0f, 10.0f, 56.0f, 56.0f), ": " + Global.GreenParts.ToString(), GreenParts);
        GUI.Box(new Rect(176.0f, 10.0f, 56.0f, 56.0f), ": " + Global.GrayParts.ToString(), GrayParts);

    }
}