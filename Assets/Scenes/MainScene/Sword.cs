using UnityEngine;

public class Sword : MonoBehaviour
{
    public float moveSpeed = 20.0f; // �ړ����x
    public float horizontalPadding = 0.1f; // ��ʂ̉�������̃p�f�B���O

    private float minX; // �ŏ�X���W
    private float maxX; // �ő�X���W

    private void Start()
    {
        // �J�����̍����ƉE��̃r���[�|�[�g���W���擾
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // �I�u�W�F�N�g�̃T�C�Y���l�����Đ����͈͂��v�Z
        minX = bottomLeft.x + horizontalPadding;
        maxX = topRight.x - horizontalPadding;
    }

    private void Update()
    {
        // �E�Ɉړ�����
        if (Input.GetKey(KeyCode.K))
        {
            MoveRight();
        }

        // ���Ɉړ�����
        if (Input.GetKey(KeyCode.D))
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        // X���W���E�Ɉړ�
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // X���W���ő�l�𒴂��Ȃ��悤�ɐ���
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }

    private void MoveLeft()
    {
        // X���W�����Ɉړ�
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // X���W���ŏ��l�𒴂��Ȃ��悤�ɐ���
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }
}