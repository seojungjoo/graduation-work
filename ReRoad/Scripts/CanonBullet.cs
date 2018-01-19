using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour {

    public Vector3 v;
    public int type;
    public float Speed;//속력
    public float damage;//데미지
    public GameObject Particle;
    public float boomrange = 1.5f;//폭발반경
    public Vector3 targetpos;//목표지점
    float t = 0;//현재 시간
    float predictTime = 0;//도착까지 예상시간
    public float angle = 45;//발사 각도
    float a = 0;
    float vxz;//속력
    float vx;
    float vz;
    float vy;

    float oy;//초기위치
    float ox;
    float oz;

    int dmg = 3;
    MoveMob[] enemies;

    // Use this for initialization
    void Start () {
        oy = this.transform.position.y;
        ox = this.transform.position.x;
        oz = this.transform.position.z;

        vxz = Speed * Mathf.Cos(angle * 3.14f / 180);
        vy = Speed * Mathf.Sin(angle * 3.14f / 180);
        //Debug.Log();
        var vxtovzangle = Vector3.Angle(Vector3.right, new Vector3(targetpos.x - ox, 0, targetpos.z - oz));
        vx = vxz * Mathf.Cos(vxtovzangle * 3.14f / 180);
        vz = vxz * Mathf.Sin(vxtovzangle * 3.14f / 180);


        float ptx = Mathf.Abs(((float)(targetpos.x - ox)) / vx);

        predictTime = ptx;
        


        a = 9.8f + 2 * (float)(targetpos.y - oy - vy * predictTime) / (predictTime * predictTime);
        
    }

    // Update is called once per frame
    void Update () {
        t += Time.deltaTime;

        Vector3 temp = transform.position;
        transform.position = new Vector3(ox, 0, oz) + vxz * t * new Vector3((targetpos.x - ox), 0, targetpos.z - oz).normalized
            + new Vector3(0, oy + vy * t + 0.5f * (a - 9.8f) * t * t, 0); ;

        Vector3 dir = transform.position - temp;

        Quaternion rot = Quaternion.LookRotation(dir, transform.up);

        transform.rotation = rot;

        if (this.transform.position.y <= -1.5)
        {
            // 폭발 데미지
            explosion();
            Destroy(this.gameObject);

        }
            


    }

    void giveDmg(Transform target)
    {
        target.SendMessage("recvDmg", dmg);
    }

    void explosion()
    {
        enemies = FindObjectsOfType<MoveMob>();

        foreach (MoveMob e in enemies)
        {
            float dist = Vector3.Distance(e.transform.position, transform.position);

            if (dist < 5.0f)
            {
                giveDmg(e.transform);
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 11)
        {
            explosion();
        }
    }

    
}
