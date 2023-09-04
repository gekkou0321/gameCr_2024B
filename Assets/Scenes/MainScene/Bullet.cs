using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の速度
    public float bulletSpeed = 10f;

    // ターゲットとなる位置
    private Vector3 targetPosition;

    private void Start()
    {
        // ターゲットの位置を設定
        SetTargetPosition();
    }

    private void Update()
    {
        // ターゲットの方向を計算して移動させる
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);

        // ターゲットに到達した場合、弾を破壊
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void SetTargetPosition()
    {
        // "Stone"タグがついているオブジェクトを探す
        GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag("Stone");
        float closestDistance = Mathf.Infinity;
        GameObject closestStone = null;

        foreach (var stone in stoneObjects)
        {
            float distance = Vector3.Distance(transform.position, stone.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestStone = stone;
            }
        }

        if (closestStone != null)
        {
            // ターゲットの位置を設定
            targetPosition = closestStone.transform.position;
            targetPosition.y -= 2f; // 少し下に調整
        }
        else
        {
            // ターゲットが見つからない場合、弾を破壊
            Destroy(gameObject);
        }
    }
}