using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terraiControl : MonoBehaviour
{
    public int TerrainLayer = 8;
    public Terrain tr;

    float width;
    float height;


    int heightWidth;
    int heightHeight;
    float[,] heights;
    float[,] originHeights;

    float[,,] originAlphas;
    float[,,] Alphas;
    int alphaWidth;
    int alphaHeight;

    bool[,] downOnce;
    public Transform me;
    public int brushSize;
    public bool able = true;
    bool startStage = true;

    public Transform place;
    public GameObject pathgo;
    public GameObject node;

    bool create = false;

    int numOfAlphaLayer;

    int heightRatio;
    int alphaRatio;

    // Use this for initialization
    void Start()
    {

        width = tr.terrainData.size.x;
        height = tr.terrainData.size.z;

        heightWidth = tr.terrainData.heightmapWidth;
        Debug.Log(heightWidth);

        heightHeight = tr.terrainData.heightmapHeight;
        Debug.Log(heightHeight);

        heights = tr.terrainData.GetHeights(0, 0, heightWidth, heightHeight);

        alphaHeight = tr.terrainData.alphamapHeight;
        alphaWidth = tr.terrainData.alphamapWidth;
        Alphas = tr.terrainData.GetAlphamaps(0, 0, alphaWidth, alphaHeight);

        originHeights = tr.terrainData.GetHeights(0, 0, heightWidth, heightHeight);
        originAlphas = tr.terrainData.GetAlphamaps(0, 0, alphaWidth, alphaHeight);

        numOfAlphaLayer = tr.terrainData.alphamapLayers;

        Debug.Log(numOfAlphaLayer);
        downOnce = new bool[heightHeight, heightWidth];


        heightRatio = (int)(heightHeight / height);
        alphaRatio = (int)(alphaHeight / height);

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



            modifyTerrain();
            smoothHeight();


            tr.terrainData.SetHeights(0, 0, heights);
            tr.terrainData.SetAlphamaps(0, 0, Alphas);
        }


    }

    void OnApplicationQuit()
    {
        tr.terrainData.SetHeights(0, 0, originHeights);
        tr.terrainData.SetAlphamaps(0, 0, originAlphas);

    }

    void modifyTerrain()
    {
        float myX = me.transform.position.x;
        float myY = me.transform.position.z;
        float randomBrush = Random.Range(4.0f, 6.0f);

        Vector2 myPos = new Vector2(myX * heightRatio, myY * heightRatio);
        Vector2 trPos;


        for (int x = (int)(myPos.x) - 14; x <= (int)(myPos.x) + 14; x++)
        {
            for (int y = (int)(myPos.y) - 14; y <= (int)(myPos.y) + 14; y++)
            {

                if (x >= 0 && y >= 0 && x < alphaWidth && y < alphaHeight)
                {

                    trPos = new Vector2(x, y);
                    float dist = Vector2.Distance(trPos, myPos);
                    //Debug.Log(Vector2.Distance(trPos, myPos));
                    if (dist < brushSize + randomBrush)
                    {
                        Alphas[y, x, 0] = 0;
                        Alphas[y, x, 1] = 0.3f;
                        Alphas[y, x, 2] = 0.7f;

                        if (dist < brushSize - 1)
                        {

                            heights[y, x] -= 0.5f * (1 - Mathf.Clamp(Mathf.Log10(dist / 1.3f), 0, 1));
                            //heights[y, x] = 0.0f;
                            //Alphas[y,x,]
                            //heights[y, x] = 0.0f;
                            //downOnce[y, x] = true;

                            //TODO : 반복X 계산으로 !
                            create = true;
                        }
                        else
                        {
                            //if(heights[(int)myPos.y, (int)myPos.x] > 0.0f)
                            //    heights[y, x] += 0.055f;
                        }
                    }

                }
            }
        }

    }

    void smoothHeight()
    {
        float myX = me.transform.position.x;
        float myY = me.transform.position.z;
        float randomBrush = Random.Range(2.0f, 4.0f);

        Vector2 myPos = new Vector2(myX * heightRatio, myY * heightRatio);
        Vector2 trPos;

        for (int x = (int)(myPos.x) - 14; x <= (int)(myPos.x) + 14; x++)
        {
            for (int y = (int)(myPos.y) - 14; y <= (int)(myPos.y) + 14; y++)
            {

                if (x >= 0 && y >= 0 && x < alphaWidth && y < alphaHeight)
                {

                    trPos = new Vector2(x, y);
                    float dist = Vector2.Distance(trPos, myPos);
                    //Debug.Log(Vector2.Distance(trPos, myPos));


                    if (dist < brushSize + 5)
                    {
                        float avg = 0;
                        float sum = 0;
                        int num = 0;

                        for (int nx = x - 2; nx < x + 3; nx++)
                        {
                            for (int ny = y - 2; ny < y + 3; ny++)
                            {
                                if (nx >= 0 && ny >= 0 && nx < alphaWidth && ny < alphaHeight)
                                {
                                    sum += heights[ny, nx];
                                    num++;
                                }
                            }
                        }

                        avg = sum / num;

                        if (heights[y, x] > 0.01f)
                            heights[y, x] = avg;


                    }

                }


            }
        }

        tr.terrainData.SetHeights(0, 0, heights);
    }


}