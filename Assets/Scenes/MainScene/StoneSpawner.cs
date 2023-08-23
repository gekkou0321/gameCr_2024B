using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    // ��������I�u�W�F�N�g�̃v���n�u
    public GameObject objectPrefab;

    // �����Ԋu�i�b�j
    public float spawnInterval;

    // ��ʂ̕�
    public float screenWidth;

    // ��ʂ̍���
    public float screenHeight;

    private void Start()
    {
        // ���Ԋu�ŃI�u�W�F�N�g�𐶐�����
        InvokeRepeating("SpawnRandomObject", 0f, spawnInterval);
    }

    private void SpawnRandomObject()
    {
        // ��ʓ��̃����_���Ȉʒu���v�Z
        Vector3 randomPosition = new Vector3(Random.Range(-screenWidth / 2f, screenWidth / 2f), 5f, 0f);

        // �I�u�W�F�N�g�𐶐�
        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }
}