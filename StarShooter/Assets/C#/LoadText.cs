using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    [Header("��J�C�Ӥ�r�ۤv��ID")]
    public int ID;

    //�Ȧs�y��Dropdown��ID��
    string SaveLanID = "SaveLanID";

    //Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt(SaveLanID));
        switch (PlayerPrefs.GetInt(SaveLanID))
        {
            //����
            case 0:
                //�H�U�T�ؼg�k���O�� ������}����Text�ݩ�
                //GetComponent<Text>().text
                //this.GetComponent<Text>().text
                //GameObject.Find("ReadText")��M�����W���ӦW�٪�����
                if(FindObjectOfType<ReadText>())
                gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().CHDatas[ID];
                break;
            //�^��
            case 1:
                if (FindObjectOfType<ReadText>())
                    gameObject.GetComponent<Text>().text = FindObjectOfType<ReadText>().ENDatas[ID];
                break;
        }
    }


    
}
