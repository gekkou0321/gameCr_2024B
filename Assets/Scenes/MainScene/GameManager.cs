using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        // �V���O���g���C���X�^���X��ݒ�
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
    }

    public int GetScore()
    {
        return score;
    }
}