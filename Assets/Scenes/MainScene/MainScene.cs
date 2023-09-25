using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    // 右のゲージの増加量
    public float rightGaugeIncreaseAmount = 0.5f;

    // 左のゲージの増加量
    public float leftGaugeIncreaseAmount = 0.5f;

    // ゲージの最大値
    public float maxGaugeValue = 100f;

    // 右のゲージ
    private float rightGauge = 0f;

    // 左のゲージ
    private float leftGauge = 0f;

    // 右のゲージ用のスライダー
    public Slider rightSlider;

    // 左のゲージ用のスライダー
    public Slider leftSlider;

    // Lcon オブジェクト
    public GameObject lconObject;

    // Rcon オブジェクト
    public GameObject rconObject;

    // Lcon オブジェクトの BulletSpawner コンポーネント
    private BulletSpawner lconBulletSpawner;

    // Rcon オブジェクトの BulletSpawner コンポーネント
    private BulletSpawner rconBulletSpawner;

    private void Start()
    {
        rightSlider.value = rightGauge;
        leftSlider.value = leftGauge;

        // Lcon オブジェクトから BulletSpawner コンポーネントを取得
        lconBulletSpawner = lconObject.GetComponent<BulletSpawner>();

        // Rcon オブジェクトから BulletSpawner コンポーネントを取得
        rconBulletSpawner = rconObject.GetComponent<BulletSpawner>();

        GameManager.Instance.ModeChange(0);

    }
    private void FixedUpdate()
    {
        
        // Kキーが押されたら右のゲージを増やす
        if (Input.GetKey(KeyCode.K))
        {
            IncreaseRightGauge();

            
        }
        else
        {
            // Kキーが押されていない場合は Rcon オブジェクトの BulletSpawner を有効にする
            rconBulletSpawner.enabled = true;
        }

        // Dキーが押されたら左のゲージを増やす
        if (Input.GetKey(KeyCode.D))
        {
            IncreaseLeftGauge();

            
        }
        else
        {
            // Dキーが押されていない場合は Lcon オブジェクトの BulletSpawner を有効にする
            lconBulletSpawner.enabled = true;
        }

        
    }

    private void IncreaseRightGauge()
    {
        if (rightSlider.value < 100f)
        {
            // Kキーが押されている間は Rcon オブジェクトの BulletSpawner を無効にする
            rconBulletSpawner.enabled = false;
            rightSlider.value += (rightGaugeIncreaseAmount);
        }
        Debug.Log("Right Gauge: " + rightSlider.value);
    }

    private void IncreaseLeftGauge()
    {
        if (leftSlider.value < 100f)
        {
            // Dキーが押されている間は Lcon オブジェクトの BulletSpawner を無効にする
            lconBulletSpawner.enabled = false;
            leftSlider.value += (leftGaugeIncreaseAmount);
        }
        Debug.Log("Right Gauge: " + leftSlider.value);
    }

    private void DecreaseRightGauge()
    {
        rightGauge -= rightGaugeIncreaseAmount*0.5f;
        rightGauge = Mathf.Clamp(rightGauge, 0f, 100f);
        Debug.Log("Right Gauge: " + rightGauge);
    }
    private void DecreaseleftGauge()
    {
        leftGauge -= leftGaugeIncreaseAmount * 0.5f;
        leftGauge = Mathf.Clamp(leftGauge, 0f, 100f);
        Debug.Log("left Gauge: " + leftGauge);
    }
   private void UpdateSliders()
    {
        // スライダーの値をゲージの値に連携
        rightSlider.value = rightGauge / maxGaugeValue;
        leftSlider.value = leftGauge / maxGaugeValue;
    }

    
}
