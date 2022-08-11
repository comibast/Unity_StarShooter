using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   //�ޥ�UI�{���w
using System.IO;        //���\Ū���P�g�J�ɮשθ��
using UnityEngine.Audio;    //�ޥ�AudioMixer�{���w

public class menu : MonoBehaviour
{
    [Header("BGM")]
    public GameObject BGM;
    //��������n���}��
    bool ControlAudio;

    /*[Header("�n���}�Ϥ�")]
    public Sprite OpenSound;
    [Header("�n�����Ϥ�")]
    public Sprite CloseSound;
    */
    [Header("�n�����s")]
    public Image ButtonSound;

    //���sStreamingAssets���|
    public string[] filePaths;
    [Header("�վ㭵�qSlider")]
    public Slider ChangeAudioSlider;
    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;

    [Header("�ѪR��Dropdown")]
    public Dropdown SizeDropdown;

    [Header("�y��Dropdown")]
    public Dropdown LanDropdown;
    //�Ȧs�y��Dropdown��ID��
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
        //�w�]��V��wasd(�n�p�g)
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
        //�ˬd�����WBGM�ƶq�O�_<=0
        if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
        {
            //�ʺA�ͦ��@�ӭI�����֪���
            Instantiate(BGM);
        }
    }

#region �i�JLevel����
    public void NextScene()
    {
        //�¦�������:(���a�n���[��)
        //Application.LoadLevel("�U�@�ӳ����W��");
        //Application.LoadLevel(ID);
        //�s��������:(�w���[��,���a���ε�)
        //SceneManager.LoadScene("�U�@�ӳ����W��");
        //SceneManager.LoadScene(ID);
        SceneManager.LoadScene("level");

    }
#endregion

#region �C������
    public void Quit()
    {
        Application.Quit();
    }
#endregion

#region ��������n��
    public void Control_Audio()
    {
        //!�ϸq
        ControlAudio = !ControlAudio;
        if(ControlAudio)
        {
            //ButtonSound.sprite = OpenSound;                                      //��k1
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/OpenAudio");     //��k2
            //Ū��OpenAudio����
            StreamingAssetsLoadTexture(1);                                         //��k3
            
        }
        else
        {
            //ButtonSound.sprite = CloseSound;                                      //��k1
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/CloseAudio");     //��k2
            //Ū��CloseAudio����
            StreamingAssetsLoadTexture(0);                                          //��k3
        }


        //AudioListener.pause = true; ���������n���R��
        //AudioListener.pause = false; ���������n���}��
        AudioListener.pause = ControlAudio;
    }
#endregion

#region StreamingAssetsŪ���Ϥ�
    void StreamingAssetsLoadTexture(int ID)
    {
        //�N���|����ഫ��2�i���ɮ�
        byte[] pngBytes = File.ReadAllBytes(filePaths[ID]);
        //�ŧi2D�Ϥ�(�Ϥ��e, �Ϥ���)
        Texture2D tex = new Texture2D(0, 0);
        //Ū���Ϥ�
        tex.LoadImage(pngBytes);
        //�N�Ϥ��ഫ��Sprite�榡(�Ϥ�, �x��(��m.x, ��m.y, �e��, ����), Pivot�����I��m(x,y))
        Sprite FormTex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        //�a�J�Ϥ���Button��Image��
        ButtonSound.sprite = FormTex;
    }
    #endregion

#region �ϥ�slider����AudioMixer���q
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
