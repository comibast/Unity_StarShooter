using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("���ʳt��")]
    public float Speed;
    [Header("�����ɶ�")]
    public float DeletTime;

    public enum SetState
    {
        PlayerBullet,
        EnemyBullet
    }
    public SetState SetStates;

    [Header("�ɤl�t��_Player")]
    public GameObject PlayerExp;
    [Header("�ɤl�t��_Enemy")]
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
            //�p�G���a�l�u
            case SetState.PlayerBullet:
                //�I��ľ�||�k��
                if (hit.GetComponent<Collider>().tag == "Enemy" || hit.GetComponent<Collider>().tag == "Asteroid")
                {
                    //����F��N�[��
                    FindObjectOfType<GM>().AddScore(AddScore);
                    //�ʺA�ͦ��z���S�Ħb���쪺��m
                    Instantiate(EnemyExp, hit.transform.position, hit.transform.rotation);
                    //�R���Q���쪺�ľ��ιk��
                    Destroy(hit.gameObject);
                    //�R���l�u
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
