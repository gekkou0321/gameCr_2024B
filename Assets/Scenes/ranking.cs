using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text[] highScoreTexts; // 1位から10位までのハイスコアを表示するTextの配列
    private int[] highScores = new int[10]; // 1位から10位までのハイスコア用の配列
    private string key = "HIGH_SCORE"; // ハイスコアの保存キー

    private int currentScore = 0; // 現在のスコア

    void Start()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = PlayerPrefs.GetInt(key + i.ToString(), 0);
            highScoreTexts[i].text = "Rank " + (i + 1) + ": " + highScores[i].ToString();
        }

        // テスト用：ランダムなスコアを生成して更新
        int randomTestScore = Random.Range(0, 100);
        UpdateScore(randomTestScore);
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;

        for (int i = 0; i < highScores.Length; i++)
        {
            if (currentScore > highScores[i])
            {
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1]; // 下位のハイスコアをずらす
                    highScoreTexts[j].text = "Rank " + (j + 1) + ": " + highScores[j].ToString();
                    PlayerPrefs.SetInt(key + j.ToString(), highScores[j]); // 保存
                }
                highScores[i] = currentScore;
                highScoreTexts[i].text = "Rank " + (i + 1) + ": " + highScores[i].ToString();
                PlayerPrefs.SetInt(key + i.ToString(), highScores[i]); // 保存
                break;
            }
        }
    }
}

