using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour
{
    [Header("�����ɶ�")]
    public float DeleteTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
