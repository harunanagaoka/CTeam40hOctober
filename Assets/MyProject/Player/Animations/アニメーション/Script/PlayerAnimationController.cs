using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private float m_playerMove;

    private void Awake()
    {
        // Animatorを取得（同じGameObjectにアタッチされている前提）
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animatorが見つかりません。PlayerAnimationControllerと同じオブジェクトにAnimatorを追加してください。");
        }
    }

    // 新Input System用の移動入力イベント
    private void OnMove(InputValue value)
    {
        Vector2 axis = value.Get<Vector2>();
        m_playerMove = axis.x;

        if (Mathf.Abs(axis.x) > 0.01f)
        {
            // 移動中
            anim.SetInteger("PlayerController", 1);
        }
        else
        {
            // 停止中（アイドル）
            anim.SetInteger("PlayerController", 0);
        }
    }

    // トリガー衝突（音符）
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Musical Note"))
        {
            // 反応アニメーションへ
            anim.SetInteger("PlayerController", 2);
        }
    }
}

