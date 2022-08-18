using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";
    [Header("�C���̰�����")]
    public Text HeightScoreText;
    [Header("�C������")]
    public Text ScoreText;
    private void Awake()
    {
        //�ˬd�̰��o���̭��O�_���x�s�ƭ�
        if (PlayerPrefs.HasKey(SaveHeightScore))
        {
            //�p�G�ثe�o��>�̰��o��
            if (PlayerPrefs.GetInt(SaveScore) > PlayerPrefs.GetInt(SaveScore))
            {
                PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
                HeightScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
                ScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
            }
        
            else
            {
                HeightScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
                ScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
            }
        }
        //�p�G�̰��o���|���x�s������ơA�N��Ĥ@���C��
        else
        {
            PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
            HeightScoreText.text =PlayerPrefs.GetInt(SaveScore).ToString();
            ScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
        }

    }



}
