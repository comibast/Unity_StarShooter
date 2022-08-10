using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用外部程式庫
using System.IO;
//使用Unity UI程式庫
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    //撰寫建立文字檔的路徑
    string Path;
    [Header("語言下拉選單")]
    public Dropdown LanDropdown;
    [Header("解析度下拉選單")]
    public Dropdown ScreenSizeDropdown;
    //讀取文字檔，並且將資料寫入 或 讀取
    FileStream file;

    public enum Platform
    {
        PC,
        Mobile
    }

    [Header("選擇要切換的平台")]
    public Platform Platforms;
    [Header("顯示文字檔兩個Dropdown資料")]
    public string[] Datas;
    WWW Reader;
    string ReaderPC;

    private void Awake()
    {
        //建立一個文字檔名稱為Save.txt，並且儲存在Application.persisentDataPath路徑下
        Path = Application.persistentDataPath + "Save.txt";

        //檢查
        if (File.Exists(Path))
        {
            //先用Log檢驗
            Debug.Log("抓取手機內的文字檔案");
            //讀取文字檔的內容
            ReadString();
        }

        //檢查此路徑是否已經有文字檔案 => 如果回傳false沒有文字檔
        else
        {
            //建立文字檔案
            Debug.Log("在手機建立一個文字檔案");
            //建立一個文字檔
            file = new FileStream(Path, FileMode.Create);
            file.Close();
        }
    }
        //按下返回按鈕就自動儲存解析度和語言的Dropdown Value
        public void SaveData()
        {
            WriteString(ScreenSizeDropdown.value + "@" + LanDropdown.value);
        }
        
        void WriteString(string Data)
        {
            //找到Application.persisentDataPath路徑下的文字檔，並開啟。
            file = new FileStream(Path, FileMode.Open);
            //把要儲存的資料的文字檔
            StreamWriter sw = new StreamWriter(file);
            //在文字檔寫入要儲存的文字
            sw.WriteLine(Data);
            //資料寫入完畢關閉文字檔
            sw.Close();
        }

        void ReadString()
        {
            switch (Platforms)
            {
                case Platform.Mobile:
                    //透過網址方式把文字檔夾的路徑轉檔，並讀出文字檔內容
                    Reader = new WWW(Path);
                    //將讀取的文字檔有@的做分割
                    Datas = Reader.text.Split('@');
                    // int.Parse文字轉成整數值
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);

                    break;
                case Platform.PC:
                    //讀取路徑的文字檔內容
                    ReaderPC = File.ReadAllText(Path);
                    Datas = ReaderPC.Split('@');
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);
                    break;
            }


        }


    }




