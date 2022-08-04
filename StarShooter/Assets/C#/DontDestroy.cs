using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad 切換場景時，物件不要被刪除。
        //gameObject 代表有此腳本的物件
        DontDestroyOnLoad(gameObject);
    }

}
