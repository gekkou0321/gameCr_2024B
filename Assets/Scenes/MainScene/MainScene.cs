using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    // �E�̃Q�[�W�̑�����
    public float rightGaugeIncreaseAmount = 0.5f;

    // ���̃Q�[�W�̑�����
    public float leftGaugeIncreaseAmount = 0.5f;

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

    // Lcon �I�u�W�F�N�g
    public GameObject lconObject;

    // Rcon �I�u�W�F�N�g
    public GameObject rconObject;

    // Lcon �I�u�W�F�N�g�� BulletSpawner �R���|�[�l���g
    private BulletSpawner lconBulletSpawner;

    // Rcon �I�u�W�F�N�g�� BulletSpawner �R���|�[�l���g
    private BulletSpawner rconBulletSpawner;

    private void Start()
    {
        rightSlider.value = rightGauge;
        leftSlider.value = leftGauge;

        // Lcon �I�u�W�F�N�g���� BulletSpawner �R���|�[�l���g���擾
        lconBulletSpawner = lconObject.GetComponent<BulletSpawner>();

        // Rcon �I�u�W�F�N�g���� BulletSpawner �R���|�[�l���g���擾
        rconBulletSpawner = rconObject.GetComponent<BulletSpawner>();

        GameManager.Instance.ModeChange(0);

    }
    private void FixedUpdate()
    {
        
        // K�L�[�������ꂽ��E�̃Q�[�W�𑝂₷
        if (Input.GetKey(KeyCode.K))
        {
            IncreaseRightGauge();

            
        }
        else
        {
            // K�L�[��������Ă��Ȃ��ꍇ�� Rcon �I�u�W�F�N�g�� BulletSpawner ��L���ɂ���
            rconBulletSpawner.enabled = true;
        }

        // D�L�[�������ꂽ�獶�̃Q�[�W�𑝂₷
        if (Input.GetKey(KeyCode.D))
        {
            IncreaseLeftGauge();

            
        }
        else
        {
            // D�L�[��������Ă��Ȃ��ꍇ�� Lcon �I�u�W�F�N�g�� BulletSpawner ��L���ɂ���
            lconBulletSpawner.enabled = true;
        }

        
    }

    private void IncreaseRightGauge()
    {
        if (rightSlider.value < 100f)
        {
            // K�L�[��������Ă���Ԃ� Rcon �I�u�W�F�N�g�� BulletSpawner �𖳌��ɂ���
            rconBulletSpawner.enabled = false;
            rightSlider.value += (rightGaugeIncreaseAmount);
        }
        Debug.Log("Right Gauge: " + rightSlider.value);
    }

    private void IncreaseLeftGauge()
    {
        if (leftSlider.value < 100f)
        {
            // D�L�[��������Ă���Ԃ� Lcon �I�u�W�F�N�g�� BulletSpawner �𖳌��ɂ���
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
        // �X���C�_�[�̒l���Q�[�W�̒l�ɘA�g
        rightSlider.value = rightGauge / maxGaugeValue;
        leftSlider.value = leftGauge / maxGaugeValue;
    }

    
}
