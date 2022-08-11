using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    [Header("輸入每個文字自己的ID")]
    public int ID;

    //暫存語言Dropdown的ID值
    string SaveLanID = "SaveLanID";

    //Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt(SaveLanID));
        switch (PlayerPrefs.GetInt(SaveLanID))
        {
            //中文
            case 0:
                //以下三種寫法都是指 抓取此腳本的Text屬性
                //GetComponent<Text>().text
                //this.GetComponent<Text>().text
                //GameObject.Find("ReadText")找尋場景上有該名稱的物件
                if(FindObjectOfType<ReadText>())
                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().CHDatas[ID];
                break;
            //英文
            case 1:
                if (FindObjectOfType<ReadText>())
                    gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().ENDatas[ID];
                break;
        }
    }


    
}
