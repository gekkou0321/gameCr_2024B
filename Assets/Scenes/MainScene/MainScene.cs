using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    // 右のゲージの増加量
    public float rightGaugeIncreaseAmount = 0.1f;

    // 左のゲージの増加量
    public float leftGaugeIncreaseAmount = 0.1f;

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
    private void Start()
    {
        rightSlider.value = rightGauge;
        leftSlider.value = leftGauge;

    }
    private void FixedUpdate()
    {

        // Kキーが押されたら右のゲージを増やす
        if (Input.GetKey(KeyCode.K))
        {
            IncreaseRightGauge();
        }


        // Dキーが押されたら左のゲージを増やす
        if (Input.GetKey(KeyCode.D))
        {
            IncreaseLeftGauge();
        }
        

        //UpdateSliders();
    }

    private void IncreaseRightGauge()
    {
        if (rightSlider.value < 100f)
        {
            rightSlider.value += (rightGaugeIncreaseAmount);
        }
        Debug.Log("Right Gauge: " + rightSlider.value);
    }

    private void IncreaseLeftGauge()
    {
        if (leftSlider.value < 100f)
        {
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
