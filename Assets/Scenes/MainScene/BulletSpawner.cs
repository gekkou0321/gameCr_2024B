using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    // ��������I�u�W�F�N�g�̃v���n�u
    public GameObject objectPrefab;

    // �����Ԋu�i�b�j
    public float spawnInterval = 2f;

    // �X���C�_�[�ւ̎Q��
    public Slider slider;

    // �X���C�_�[��臒l�i1�ȏ�Ȃ琶���j
    private float sliderThreshold = 0.01f;

    private void Start()
    {
        // ���Ԋu�ŃI�u�W�F�N�g�𐶐�����
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // "Stone"�^�O�����Ă���I�u�W�F�N�g��T��
        GameObject[] stoneObjects = GameObject.FindGameObjectsWithTag("Stone");

        foreach (GameObject stone in stoneObjects)
        {
            // Stone�I�u�W�F�N�g�Ƃ̋������v�Z�ix���W�̍����݂̂��l���j
            float xDistance = Mathf.Abs(transform.position.x - stone.transform.position.x);

            // �X���C�_�[�̒l��臒l�ȏォ�Ax���W�̋�����4�ȉ��̏ꍇ�ɐ���
            if (slider.value >= sliderThreshold && xDistance <= 4&&this.enabled)
            {
                // �I�u�W�F�N�g�𐶐�
                slider.value = slider.value - 0.5f;
                Instantiate(objectPrefab, transform.position, Quaternion.identity);
                break; // ��x���������烋�[�v�𔲂���
            }
        }
    }
}