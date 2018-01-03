using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terraiControl : MonoBehaviour
{
    public int TerrainLayer = 8;
    public Terrain tr;
    int width;
    int height;
    float[,] heights;
    float[,] originHeights;
    public Transform me;
    public int brushSize = 5;
    public bool able = true;
    bool startStage = true;

    public Transform place;
    public GameObject pathgo;
    public GameObject node;

    bool create = false;
    // Use this for initialization
    void Start()
    {

        width = tr.terrainData.heightmapWidth;
        height = tr.terrainData.heightmapHeight;
        heights = tr.terrainData.GetHeights(0, 0, width, height);

        originHeights = tr.terrainData.GetHeights(0, 0, width, height);

        Debug.Log(width);
        Debug.Log(height);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            able = !able;
        }

        if (able)
        {
            /*
            //Vector3 pos = hitInfo.point;

            //int l = hitInfo.transform.gameObject.layer;
            //if (l == TerrainLayer && pos.y > 29)
            //{

            //    Vector2 myPos = me.transform.position;
            //    Vector2 trPos;
            //    for (int x = 0; x < 513; x++)
            //    {
            //        for (int y = 0; y < 513; y++)
            //        {
            //            trPos = new Vector2(x, y);
            //            if (Vector2.Distance(trPos, myPos) < brushSize)
            //            {
            //                heights[y, x] = 0.03f;
            //            }
            //        }
            //    }
            //    tr.terrainData.SetHeights(0, 0, heights);
            */



            float myX = me.transform.position.x;
            float myY = me.transform.position.z;

            Vector2 trPos;
            Vector2 myPos = new Vector2(myX, myY);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    trPos = new Vector2(x, y);
                    //Debug.Log(Vector2.Distance(trPos, myPos));
                    if (Vector2.Distance(trPos, myPos) < brushSize)
                    {
                        
                        heights[y, x] = 0.0f;
                        //TODO : 반복X 계산으로 !
                        create = true;
                    }
                }
            }
            if (create == true)
            {
                //GameObject g = Instantiate(node, myPos, Quaternion.identity);
                //g.SetActive(true);
            }

            create = false;

            tr.terrainData.SetHeights(0, 0, heights);


        }


    }

    void OnApplicationQuit()
    {
        tr.terrainData.SetHeights(0, 0, originHeights);

    }

    
}
