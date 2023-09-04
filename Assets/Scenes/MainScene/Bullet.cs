using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �e�̑��x
    public float bulletSpeed = 10f;

    // �^�[�Q�b�g�ƂȂ�ʒu
    private Vector3 targetPosition;

    private void Start()
    {
        // �^�[�Q�b�g�̈ʒu��ݒ�
        SetTargetPosition();
    }

    private void Update()
    {
        // �^�[�Q�b�g�̕������v�Z���Ĉړ�������
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);

        // �^�[�Q�b�g�ɓ��B�����ꍇ�A�e��j��
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void SetTargetPosition()
    {
        // "Stone"�^�O�����Ă���I�u�W�F�N�g��T��
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
            // �^�[�Q�b�g�̈ʒu��ݒ�
            targetPosition = closestStone.transform.position;
            targetPosition.y -= 2f; // �������ɒ���
        }
        else
        {
            // �^�[�Q�b�g��������Ȃ��ꍇ�A�e��j��
            Destroy(gameObject);
        }
    }
}