using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public float DeleteTime;

    public GameObject Bullet;
    [Header("幾秒產生一顆子彈")]
    public float SetTime;
    float ScriptTime;
    [Header("子彈的參考位置")]
    public Transform TargetPoint;
    public GameObject Ex;
    [Header("撞傷")]
    public float getHurt;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("CreateBullets", SetTime, SetTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //z軸發射是forward, y軸是up或down, x軸是left或right
    }

    void CreateBullets()
    {
        Instantiate(Bullet, TargetPoint.transform.position, TargetPoint.transform.rotation);
    }
    /// <summary>
    /// 被隕石撞傷，隕石爆炸消失
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            FindObjectOfType<GM>().HurtPlayer(getHurt);
            Instantiate(Ex, gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }


}
