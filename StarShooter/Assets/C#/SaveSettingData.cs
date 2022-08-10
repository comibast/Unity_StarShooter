using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ϥΥ~���{���w
using System.IO;
//�ϥ�Unity UI�{���w
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    //���g�إߤ�r�ɪ����|
    string Path;
    [Header("�y���U�Կ��")]
    public Dropdown LanDropdown;
    [Header("�ѪR�פU�Կ��")]
    public Dropdown ScreenSizeDropdown;
    //Ū����r�ɡA�åB�N��Ƽg�J �� Ū��
    FileStream file;

    public enum Platform
    {
        PC,
        Mobile
    }

    [Header("��ܭn���������x")]
    public Platform Platforms;
    [Header("��ܤ�r�ɨ��Dropdown���")]
    public string[] Datas;
    WWW Reader;
    string ReaderPC;

    private void Awake()
    {
        //�إߤ@�Ӥ�r�ɦW�٬�Save.txt�A�åB�x�s�bApplication.persisentDataPath���|�U
        Path = Application.persistentDataPath + "Save.txt";

        //�ˬd
        if (File.Exists(Path))
        {
            //����Log����
            Debug.Log("������������r�ɮ�");
            //Ū����r�ɪ����e
            ReadString();
        }

        //�ˬd�����|�O�_�w�g����r�ɮ� => �p�G�^��false�S����r��
        else
        {
            //�إߤ�r�ɮ�
            Debug.Log("�b����إߤ@�Ӥ�r�ɮ�");
            //�إߤ@�Ӥ�r��
            file = new FileStream(Path, FileMode.Create);
            file.Close();
        }
    }
        //���U��^���s�N�۰��x�s�ѪR�שM�y����Dropdown Value
        public void SaveData()
        {
            WriteString(ScreenSizeDropdown.value + "@" + LanDropdown.value);
        }
        
        void WriteString(string Data)
        {
            //���Application.persisentDataPath���|�U����r�ɡA�ö}�ҡC
            file = new FileStream(Path, FileMode.Open);
            //��n�x�s����ƪ���r��
            StreamWriter sw = new StreamWriter(file);
            //�b��r�ɼg�J�n�x�s����r
            sw.WriteLine(Data);
            //��Ƽg�J����������r��
            sw.Close();
        }

        void ReadString()
        {
            switch (Platforms)
            {
                case Platform.Mobile:
                    //�z�L���}�覡���r�ɧ������|���ɡA��Ū�X��r�ɤ��e
                    Reader = new WWW(Path);
                    //�NŪ������r�ɦ�@��������
                    Datas = Reader.text.Split('@');
                    // int.Parse��r�ন��ƭ�
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);

                    break;
                case Platform.PC:
                    //Ū�����|����r�ɤ��e
                    ReaderPC = File.ReadAllText(Path);
                    Datas = ReaderPC.Split('@');
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);
                    break;
            }


        }


    }




