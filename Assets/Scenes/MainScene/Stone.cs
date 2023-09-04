using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
    // �I�u�W�F�N�g�̈ړ����x
    public float moveSpeed = 5f;
    private int hit = 0;

    public int scoreValue = 10; // �X�R�A�̒l

    private void Update()
    {
        // ���Ɉړ�����
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DecreaseScore(scoreValue);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            hit++;
            if (hit == 4)
            {
                IncreaseScore(scoreValue);
                Destroy(gameObject);
                hit = 0;
            }
        }
    }

    private void IncreaseScore(int amount)
    {
        // �X�R�A�����Z���A�e�L�X�g�ɔ��f
        GameManager.Instance.AddScore(amount);
    }

    private void DecreaseScore(int amount)
    {
        // �X�R�A�����Z���A�e�L�X�g�ɔ��f
        GameManager.Instance.SubtractScore(amount);
    }

    
}