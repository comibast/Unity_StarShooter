using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad ���������ɡA���󤣭n�Q�R���C
        //gameObject �N�����}��������
        DontDestroyOnLoad(gameObject);
    }

}
