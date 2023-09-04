using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
    // オブジェクトの移動速度
    public float moveSpeed = 5f;
    private int hit = 0;

    public int scoreValue = 10; // スコアの値

    private void Update()
    {
        // 下に移動する
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
        // スコアを加算し、テキストに反映
        GameManager.Instance.AddScore(amount);
    }

    private void DecreaseScore(int amount)
    {
        // スコアを減算し、テキストに反映
        GameManager.Instance.SubtractScore(amount);
    }

    
}