using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // �K�v�Ȗ��O��Ԃ�ǉ�

public class ranking : MonoBehaviour
{
    public Text highScoreText; // �n�C�X�R�A��\������Text
    private int highScore; // �n�C�X�R�A�p�ϐ�
    private string key = "HIGH SCORE"; // �n�C�X�R�A�̕ۑ��L�[
    private int currentScore = 0; // ���݂̃X�R�A

    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    void Update()
    {
        // ���Ɍ��݂̃X�R�A�������_���ɐ��������
        currentScore = Random.Range(0, 100);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(key, highScore);
            highScoreText.text = "HighScore: " + highScore.ToString();
        }
    }
}

