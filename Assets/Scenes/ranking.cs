using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text[] highScoreTexts; // 1�ʂ���10�ʂ܂ł̃n�C�X�R�A��\������Text�̔z��
    private int[] highScores = new int[10]; // 1�ʂ���10�ʂ܂ł̃n�C�X�R�A�p�̔z��
    private string key = "HIGH_SCORE"; // �n�C�X�R�A�̕ۑ��L�[

    private int currentScore = 0; // ���݂̃X�R�A

    void Start()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = PlayerPrefs.GetInt(key + i.ToString(), 0);
            highScoreTexts[i].text = "Rank " + (i + 1) + ": " + highScores[i].ToString();
        }

        // �e�X�g�p�F�����_���ȃX�R�A�𐶐����čX�V
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
                    highScores[j] = highScores[j - 1]; // ���ʂ̃n�C�X�R�A�����炷
                    highScoreTexts[j].text = "Rank " + (j + 1) + ": " + highScores[j].ToString();
                    PlayerPrefs.SetInt(key + j.ToString(), highScores[j]); // �ۑ�
                }
                highScores[i] = currentScore;
                highScoreTexts[i].text = "Rank " + (i + 1) + ": " + highScores[i].ToString();
                PlayerPrefs.SetInt(key + i.ToString(), highScores[i]); // �ۑ�
                break;
            }
        }
    }
}

