using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("�T�w�C�X���ͦ��@�Ӫ���")]
    public float SetTime;
    [Header("�ĤH")]
    public GameObject[] Enemys;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemys", SetTime, SetTime);
    }

    void CreateEnemys()
    {
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}