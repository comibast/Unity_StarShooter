using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("移動速度")]
    public float Speed;
    [Header("消失時間")]
    public float DeletTime;

    public enum SetState
    {
        PlayerBullet,
        EnemyBullet
    }
    public SetState SetStates;

    [Header("粒子系統_Player")]
    public GameObject PlayerExp;
    [Header("粒子系統_Enemy")]
    public GameObject EnemyExp;

    public float HurtPlayerNum;
    public int AddScore;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeletTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider hit)
    {
        switch (SetStates)
        {
            //如果玩家子彈
            case SetState.PlayerBullet:
                //碰到敵機||隕石
                if (hit.GetComponent<Collider>().tag == "Enemy" || hit.GetComponent<Collider>().tag == "Asteroid")
                {
                    //打到東西就加分
                    FindObjectOfType<GM>().AddScore(AddScore);
                    //動態生成爆炸特效在打到的位置
                    Instantiate(EnemyExp, hit.transform.position, hit.transform.rotation);
                    //刪除被打到的敵機或隕石
                    Destroy(hit.gameObject);
                    //刪除子彈
                    Destroy(gameObject);
                }
                break;
            case SetState.EnemyBullet:
                if (hit.GetComponent<Collider>().tag == "Player")
                {
                    Debug.Log(hit.GetComponent<Collider>().tag);
                    FindObjectOfType<GM>().HurtPlayer(HurtPlayerNum);
                    Instantiate(PlayerExp, hit.transform.position, hit.transform.rotation);
                    Destroy(gameObject);
                }
                break;

        }
    }

}
