using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    [Header("�T�w�C�X��ͦ��@�Ӫ���")]
    public float SetTime;
    [Header("�ĤH")]
    public GameObject[] Enemys;

    [Header("X��ɳ̤j��")]
    public float MaxX;
    [Header("X��ɳ̤p��")]
    public float MinX;

    [Header("PauseUI")]
    public GameObject PauseUI;

    [Header("���a�`��q")]
    public float TotalHP;
    //�{�����p�⪱�a��q
    public float ScriptHP;
    [Header("���a���")]
    public Image PlayerHPImage;

    [Header("���Ƥ�r")]
    public Text ScoreText;
    int TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        ScriptHP = TotalHP;

        InvokeRepeating("CreateEnemys", SetTime, SetTime);
    }

    void CreateEnemys()
    {
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(MinX, MaxX), transform.position.y, transform.position.z), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause(bool isPause)
    {
        //Time.timeScale = 0;   ����ɶ��Ȱ�
        //Time.timeScale = 1;   ����ɶ��_��
        /*
        if(isPause){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }*/
        PauseUI.SetActive(isPause ? true : false);
        FindObjectOfType<Player>().enabled = isPause ? false : true;  //�Ȱ������ƹ��I���쪱�a����
        Time.timeScale = isPause ? 0 : 1;
    }
   
    public void HurtPlayer(float Hurt)
    {
        ScriptHP -= Hurt;
        Debug.Log("TotalHP:" + TotalHP);
        PlayerHPImage.fillAmount = ScriptHP / TotalHP;
        if (PlayerHPImage.fillAmount <= 0)
        {
            Application.LoadLevel("GameOver");
        }
    }

    public void AddScore(int Add)
    {
        TotalScore += Add;
        ScoreText.text = "Score:" + TotalScore;
    }

}
