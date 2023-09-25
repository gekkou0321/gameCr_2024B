using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 必要な名前空間を追加

public class ranking : MonoBehaviour
{
    public Text highScoreText; // ハイスコアを表示するText
    private int highScore; // ハイスコア用変数
    private string key = "HIGH SCORE"; // ハイスコアの保存キー
    private int currentScore = 0; // 現在のスコア

    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    void Update()
    {
        // 仮に現在のスコアをランダムに生成する例
        currentScore = Random.Range(0, 100);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(key, highScore);
            highScoreText.text = "HighScore: " + highScore.ToString();
        }
    }
}

