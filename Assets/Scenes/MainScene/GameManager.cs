using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 100; // スコア

    // GameManagerのインスタンスをシングルトンとして扱うための変数
    private static GameManager instance;

    public Text scoreText; // スコアを表示するテキスト

    // 右のゲージ用のスライダー
    public Slider rightSlider;

    // 左のゲージ用のスライダー
    public Slider leftSlider;

    // Lcon オブジェクト
    public GameObject lconObject;

    // Rcon オブジェクト
    public GameObject rconObject;

    public GameObject swordObject;


    // メインコントローラーへの参照
    public MainScene mainSceneScript;

    // 弾スポナーへの参照
    public BulletSpawner bspawnerL;
    public BulletSpawner bspawnerR;
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

    public void ModeChange(int mode) 
    {
        if (mode == 0) { 
            swordObject.SetActive(false); 
            rconObject.SetActive(true); lconObject.SetActive(true);
            rightSlider.gameObject.SetActive(true); leftSlider.gameObject.SetActive(true); 
            mainSceneScript.enabled = true; bspawnerL.enabled = true; bspawnerR.enabled = true;
        }
        if (mode == 1) { swordObject.SetActive(true); 
            rconObject.SetActive(false); lconObject.SetActive(false);
            rightSlider.gameObject.SetActive(false); leftSlider.gameObject.SetActive(false);
            mainSceneScript.enabled = false; bspawnerL.enabled = false; bspawnerR.enabled = false;
        }
    }


    private void Update()
    {
        // スコアをテキストに反映
        scoreText.text = "SCORE: " + GetScore();

        if (Input.GetKey(KeyCode.B)) { ModeChange(1); }
        if (Input.GetKey(KeyCode.V)) { ModeChange(0); }
    }


    
}