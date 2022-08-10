using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadText : MonoBehaviour
{
    //�����ɸ��|
    string CHPath;
    //�^���ɸ��|
    string ENPath;

    [Header("��ܤ����r�ɸ��")]
    public string CHData;
    [Header("��ܭ^���r�ɸ��")]
    public string ENData;

    [Header("��ܤ����r�ɸ��")]
    public string[] CHDatas;
    [Header("��ܭ^���r�ɸ��")]
    public string[] ENDatas;

    public enum Platform
    {
        PC,
        Mobile
    }

    [Header("��ܭn���������x")]
    public Platform Platforms;

    WWW CHreader;
    WWW ENreader;

    private void Awake()
    {
        CHPath = Application.streamingAssetsPath + "/CH.txt";
        ENPath = Application.streamingAssetsPath + "/EN.txt";
        switch (Platforms)
        {
            case Platform.Mobile:
                //�z�L���}�覡��StreamingAssets��Ƹ��|����
                CHreader = new WWW(CHPath);
                ENreader = new WWW(ENPath);
                CHDatas = CHreader.text.Split('\n');
                ENDatas = ENreader.text.Split('\n');
                break;
            case Platform.PC:
                #region PC��Ū����r��
                //Ū�����|���ɮפ��e
                CHData = File.ReadAllText(CHPath);
                ENData = File.ReadAllText(ENPath);
                //Ū�X�Ӫ���ƶi�����
                CHDatas = CHData.Split('\n');
                ENDatas = ENData.Split('\n');
                #endregion
                break;
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
