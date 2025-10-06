using UnityEngine;
using UnityEngine.InputSystem;

public class P1Controller : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] private float m_playerMoveSpeed = 1f;

    private Vector3 m_velocity;

    // 通知を受け取るメソッド名は「On + Action名」である必要がある
    private void OnMove(InputValue value)
    {
        // MoveActionの入力値を取得
        var axis = value.Get<Vector2>();

        // 移動速度を保持
        m_velocity = new Vector3(axis.x, 0, 0);
    }

    private void Update()
    {
        // オブジェクト移動
        transform.position += m_playerMoveSpeed * m_velocity * Time.deltaTime;
    }
}

