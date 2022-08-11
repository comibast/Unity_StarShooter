using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //引用UI程式庫
using System.IO;        //允許讀取與寫入檔案或資料
using UnityEngine.Audio;    //引用AudioMixer程式庫

public class menu : MonoBehaviour
{
    [Header("BGM")]
    public GameObject BGM;
    //控制整體聲音開關
    bool ControlAudio;

    /*[Header("聲音開圖片")]
    public Sprite OpenSound;
    [Header("聲音關圖片")]
    public Sprite CloseSound;
    */
    [Header("聲音按鈕")]
    public Image ButtonSound;

    //佔存StreamingAssets路徑
    public string[] filePaths;
    [Header("調整音量Slider")]
    public Slider ChangeAudioSlider;
    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;

    [Header("解析度Dropdown")]
    public Dropdown SizeDropdown;

    [Header("語言Dropdown")]
    public Dropdown LanDropdown;
    //暫存語言Dropdown的ID值
    string SaveLanID = "SaveLanID";

    public InputField[] Keyboards;

    private void Awake()
    {
        filePaths = Directory.GetFiles(Application.streamingAssetsPath, "*.png");

#if UNITY_STANDALONE_WIN
        SizeDropdown.interactable = true;
#endif
#if UNITY_ANDROID || UNITY_IOS
        SizeDropdown.interactable = false;
#endif
        //預設方向鍵wasd(要小寫)
        if(Staticvar.KeyboardsState[0] == null || Staticvar.KeyboardsState[1] == null || Staticvar.KeyboardsState[2] == null || Staticvar.KeyboardsState[3] == null)
        {
            Keyboards[0].text = "w";
            Keyboards[1].text = "s";
            Keyboards[2].text = "a";
            Keyboards[3].text = "d";
            for (int i = 0; i < Keyboards.Length; i++)
            Staticvar.KeyboardsState[i] = Keyboards[i].text;
        }
        

    }

    void Start()
    {
        //檢查場景上BGM數量是否<=0
        if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
        {
            //動態生成一個背景音樂物件
            Instantiate(BGM);
        }
    }

#region 進入Level場景
    public void NextScene()
    {
        //舊式換場景:(玩家要等加載)
        //Application.LoadLevel("下一個場景名稱");
        //Application.LoadLevel(ID);
        //新式換場景:(預先加載,玩家不用等)
        //SceneManager.LoadScene("下一個場景名稱");
        //SceneManager.LoadScene(ID);
        SceneManager.LoadScene("level");

    }
#endregion

#region 遊戲關閉
    public void Quit()
    {
        Application.Quit();
    }
#endregion

#region 控制整體聲音
    public void Control_Audio()
    {
        //!反義
        ControlAudio = !ControlAudio;
        if(ControlAudio)
        {
            //ButtonSound.sprite = OpenSound;                                      //方法1
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/OpenAudio");     //方法2
            //讀取OpenAudio圖檔
            StreamingAssetsLoadTexture(1);                                         //方法3
            
        }
        else
        {
            //ButtonSound.sprite = CloseSound;                                      //方法1
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/CloseAudio");     //方法2
            //讀取CloseAudio圖檔
            StreamingAssetsLoadTexture(0);                                          //方法3
        }


        //AudioListener.pause = true; 整體環境聲音靜音
        //AudioListener.pause = false; 整體環境聲音開啟
        AudioListener.pause = ControlAudio;
    }
#endregion

#region StreamingAssets讀取圖片
    void StreamingAssetsLoadTexture(int ID)
    {
        //將路徑資料轉換成2進位檔案
        byte[] pngBytes = File.ReadAllBytes(filePaths[ID]);
        //宣告2D圖片(圖片寬, 圖片高)
        Texture2D tex = new Texture2D(0, 0);
        //讀取圖片
        tex.LoadImage(pngBytes);
        //將圖片轉換成Sprite格式(圖片, 矩形(位置.x, 位置.y, 寬度, 高度), Pivot中心點位置(x,y))
        Sprite FormTex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        //帶入圖片到Button的Image中
        ButtonSound.sprite = FormTex;
    }
    #endregion

#region 使用slider控制AudioMixer音量
    public void ChangeAudio_Slider()
    {
        //AudioListener.volume = ChangeAudioSlider.value;
        AudioMixerObj.SetFloat("BGM", ChangeAudioSlider.value);
    }
#endregion

    public void ChangeScreenSize(){
        switch (SizeDropdown.value){
            case 0:
                Screen.SetResolution(1080, 1920, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;
            }
    }

    public void ChangeLan(){
        //Debug.Log(LanDropdown.value);
      PlayerPrefs.SetInt(SaveLanID, LanDropdown.value);
    }
    //
    public void SetKeyboard(int ID){
        Staticvar.KeyboardsState[ID] = Keyboards[ID].text;
    }
}
