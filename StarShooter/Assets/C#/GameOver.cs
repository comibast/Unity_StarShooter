using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string SaveScore = "SaveScore";
    string SaveHeightScore = "SaveHeightScore";
    [Header("遊戲最高分數")]
    public Text HeightScoreText;
    [Header("遊戲分數")]
    public Text ScoreText;
    private void Awake()
    {
        //檢查最高得分裡面是否有儲存數值
        if (PlayerPrefs.HasKey(SaveHeightScore))
        {
            //如果目前得分>最高得分
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
        //如果最高得分尚未儲存任何分數，代表第一次遊玩
        else
        {
            PlayerPrefs.SetInt(SaveHeightScore, PlayerPrefs.GetInt(SaveScore));
            HeightScoreText.text =PlayerPrefs.GetInt(SaveScore).ToString();
            ScoreText.text = PlayerPrefs.GetInt(SaveScore).ToString();
        }

    }



}
