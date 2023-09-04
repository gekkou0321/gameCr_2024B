using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 100; // スコア

    // GameManagerのインスタンスをシングルトンとして扱うための変数
    private static GameManager instance;

    public Text scoreText; // スコアを表示するテキスト

    // GameManagerのインスタンスを取得するプロパティ
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // スコアを加算する関数
    public void AddScore(int amount)
    {
        score += amount;
    }

    // スコアを減算する関数
    public void SubtractScore(int amount)
    {
        score -= amount;
        if (score < 0)
        {
            score = 0; // スコアが負にならないようにする
        }
    }

    // 現在のスコアを取得する関数
    public int GetScore()
    {
        return score;
    }

    private void Update()
    {
        // スコアをテキストに反映
        scoreText.text = "SCORE: " + GetScore();
    }
}