using UnityEngine;
using UnityEngine.InputSystem;

public class P1_controller : MonoBehaviour
{
    [Header("PlayerSpeed")]
    [SerializeField] private float PlayerMoveSpeed = 1;

    private Vector3 _velocity;

    // 通知を受け取るメソッド名は「On + Action名」である必要がある
    private void OnMove(InputValue value)
    {
        // MoveActionの入力値を取得
        var axis = value.Get<Vector2>();

        // 移動速度を保持
        _velocity = new Vector3(axis.x, 0, 0);
    }

    private void Update()
    {
        // オブジェクト移動
        transform.position += PlayerMoveSpeed * _velocity * Time.deltaTime;
    }
}
