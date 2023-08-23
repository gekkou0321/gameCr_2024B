using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    // �E�̃Q�[�W�̑�����
    public float rightGaugeIncreaseAmount = 0.1f;

    // ���̃Q�[�W�̑�����
    public float leftGaugeIncreaseAmount = 0.1f;

    // �Q�[�W�̍ő�l
    public float maxGaugeValue = 100f;

    // �E�̃Q�[�W
    private float rightGauge = 0f;

    // ���̃Q�[�W
    private float leftGauge = 0f;

    // �E�̃Q�[�W�p�̃X���C�_�[
    public Slider rightSlider;

    // ���̃Q�[�W�p�̃X���C�_�[
    public Slider leftSlider;
    private void Start()
    {
        rightSlider.value = rightGauge;
        leftSlider.value = leftGauge;

    }
    private void FixedUpdate()
    {

        // K�L�[�������ꂽ��E�̃Q�[�W�𑝂₷
        if (Input.GetKey(KeyCode.K))
        {
            IncreaseRightGauge();
        }


        // D�L�[�������ꂽ�獶�̃Q�[�W�𑝂₷
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
        // �X���C�_�[�̒l���Q�[�W�̒l�ɘA�g
        rightSlider.value = rightGauge / maxGaugeValue;
        leftSlider.value = leftGauge / maxGaugeValue;
    }

    
}
