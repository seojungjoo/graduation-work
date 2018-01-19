using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDeleteTower : MonoBehaviour
{
    bool CreateTower = false;
    bool DeleteTower = false;
    public bool isCreate = false;//지을수 있냐?
    public bool isCollision = false;
    public GameObject CreatingTower;
    public GameObject basicTower;

    public GameObject unableArea;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision == true)
        {
            var ct = CreatingTower.transform.Find("Body/Head/LightGun_Head").GetComponent<MeshRenderer>();
            ct.material.color = new Color(1, 0, 0);
            var ct2 = CreatingTower.transform.Find("LightGun_Basement").GetComponent<MeshRenderer>();
            ct2.material.color = new Color(1, 0, 0);
            var ct3 = CreatingTower.transform.Find("Body/LightGun_Body").GetComponent<MeshRenderer>();
            ct3.material.color = new Color(1, 0, 0);
            isCreate = false;
        }

        if (Input.GetKeyDown("t") && Global.GreenParts >= 2 && Global.GrayParts >= 1)
        {
            CreateTower = true;
            unableArea.SetActive(true);
        }

        if (Input.GetKeyDown("g"))
        {
            DeleteTower = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (CreateTower == true && isCreate && !isCollision)
            {
                CreateTower = false;
                unableArea.SetActive(false);

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



                    isCreate = true;
                    if (isCollision == false)
                    {
                        var ct = CreatingTower.transform.Find("Body/Head/LightGun_Head").GetComponent<MeshRenderer>();
                        ct.material.color = new Color(39f / 255f, 1, 228f / 255f);
                        var ct2 = CreatingTower.transform.Find("LightGun_Basement").GetComponent<MeshRenderer>();
                        ct2.material.color = new Color(39f / 255f, 1, 228f / 255f);
                        var ct3 = CreatingTower.transform.Find("Body/LightGun_Body").GetComponent<MeshRenderer>();
                        ct3.material.color = new Color(39f / 255f, 1, 228f / 255f);
                    }
                }
                else
                {

                    var ct = CreatingTower.transform.Find("Body/Head/LightGun_Head").GetComponent<MeshRenderer>();
                    ct.material.color = new Color(1, 0, 0);
                    var ct2 = CreatingTower.transform.Find("LightGun_Basement").GetComponent<MeshRenderer>();
                    ct2.material.color = new Color(1, 0, 0);
                    var ct3 = CreatingTower.transform.Find("Body/LightGun_Body").GetComponent<MeshRenderer>();
                    ct3.material.color = new Color(1, 0, 0);
                    isCreate = false;

                }
            }
        }
    }
}