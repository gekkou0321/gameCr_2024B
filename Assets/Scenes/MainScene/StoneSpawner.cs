using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    // 生成するオブジェクトのプレハブ
    public GameObject objectPrefab;

    // 生成間隔（秒）
    public float spawnInterval;

    // 画面の幅
    public float screenWidth;

    // 画面の高さ
    public float screenHeight;

    private void Start()
    {
        // 一定間隔でオブジェクトを生成する
        InvokeRepeating("SpawnRandomObject", 0f, spawnInterval);
    }

    private void SpawnRandomObject()
    {
        // 画面内のランダムな位置を計算
        Vector3 randomPosition = new Vector3(Random.Range(-screenWidth / 2f, screenWidth / 2f), 5f, 0f);

        // オブジェクトを生成
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }
}