using UnityEngine;

public class Sword : MonoBehaviour
{
    public float moveSpeed = 20.0f; // 移動速度
    public float horizontalPadding = 0.1f; // 画面の横幅からのパディング

    private float minX; // 最小X座標
    private float maxX; // 最大X座標

    private void Start()
    {
        // カメラの左下と右上のビューポート座標を取得
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // オブジェクトのサイズを考慮して制限範囲を計算
        minX = bottomLeft.x + horizontalPadding;
        maxX = topRight.x - horizontalPadding;
    }

    private void Update()
    {
        // 右に移動する
        if (Input.GetKey(KeyCode.K))
        {
            MoveRight();
        }

        // 左に移動する
        if (Input.GetKey(KeyCode.D))
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        // X座標を右に移動
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // X座標が最大値を超えないように制限
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }

    private void MoveLeft()
    {
        // X座標を左に移動
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // X座標が最小値を超えないように制限
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }
}