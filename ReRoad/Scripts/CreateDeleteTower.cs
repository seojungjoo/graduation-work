using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDeleteTower : MonoBehaviour
{
    bool CreateTower = false;
    bool DeleteTower = false;
    public GameObject CreatingTower;
    public GameObject basicTower;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t") && Global.GreenParts >= 2 && Global.GrayParts >= 1)
        {
            CreateTower = true;
        }

        if (Input.GetKeyDown("g"))
        {
            DeleteTower = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (CreateTower == true)
            {
                CreateTower = false;
                Instantiate(basicTower, CreatingTower.transform.position, CreatingTower.transform.rotation);
                CreatingTower.transform.position = new Vector3(.0f, .0f, .0f);

                Global.GreenParts -= 2;
                Global.GrayParts -= 1;
            }

            if (DeleteTower == true)
            {
                DeleteTower = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    if (hit.collider.tag == "tower")
                    {
                        Destroy(hit.collider.gameObject);
                        Global.GreenParts += 1;
                    }
                }
            }


        }

        if (CreateTower == true)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (hit.collider.tag == "terrain")
                {
                    CreatingTower.transform.position = hit.point;

                }
                else
                {
                    CreatingTower.transform.position = new Vector3(.0f, .0f, .0f);
                }
            }
        }
    }
}