using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 100; // �X�R�A

    // GameManager�̃C���X�^���X���V���O���g���Ƃ��Ĉ������߂̕ϐ�
    private static GameManager instance;

    public Text scoreText; // �X�R�A��\������e�L�X�g

    // GameManager�̃C���X�^���X���擾����v���p�e�B
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

    // �X�R�A�����Z����֐�
    public void AddScore(int amount)
    {
        score += amount;
    }

    // �X�R�A�����Z����֐�
    public void SubtractScore(int amount)
    {
        score -= amount;
        if (score < 0)
        {
            score = 0; // �X�R�A�����ɂȂ�Ȃ��悤�ɂ���
        }
    }

    // ���݂̃X�R�A���擾����֐�
    public int GetScore()
    {
        return score;
    }

    private void Update()
    {
        // �X�R�A���e�L�X�g�ɔ��f
        scoreText.text = "SCORE: " + GetScore();
    }
}