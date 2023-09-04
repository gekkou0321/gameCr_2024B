using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    // 生成するオブジェクトのプレハブ
    public GameObject objectPrefab;

    // 生成間隔（秒）
    public float spawnInterval = 2f;

    // スライダーへの参照
    public Slider slider;

    // スライダーの閾値（1以上なら生成）
    private float sliderThreshold = 0.01f;

    private void Start()
    {
        // 一定間隔でオブジェクトを生成する
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // "Stone"タグがついているオブジェクトを探す
        GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag("Stone");

        foreach (GameObject stone in stoneObjects)
        {
            // Stoneオブジェクトとの距離を計算（x座標の差分のみを考慮）
            float xDistance = Mathf.Abs(transform.position.x - stone.transform.position.x);

            // スライダーの値が閾値以上かつ、x座標の距離が4以下の場合に生成
            if (slider.value >= sliderThreshold && xDistance <= 4&&this.enabled)
            {
                // オブジェクトを生成
                slider.value = slider.value - 0.5f;
                Instantiate(objectPrefab, transform.position, Quaternion.identity);
                break; // 一度生成したらループを抜ける
            }
        }
    }
}