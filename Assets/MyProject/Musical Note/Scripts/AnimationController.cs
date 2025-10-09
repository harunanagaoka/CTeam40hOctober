using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField]
    private string m_boolParameterName = "isHit";

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        // 初期状態で再生しないようにする
        m_animator.SetBool(m_boolParameterName, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突相手のタグをチェック
        if (collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Cymbal"))
        {
            // アニメーションを一度だけ再生
            StartCoroutine(PlayAnimationOnce());
        }
    }

    private IEnumerator PlayAnimationOnce()
    {
        // すでに再生中なら無視
        if (m_animator.GetBool(m_boolParameterName))
            yield break;

        // アニメーション再生開始
        m_animator.SetBool(m_boolParameterName, true);

        // 現在のステート情報を取得（Take001の長さを得る）
        yield return null; // 1フレーム待つ（確実にステートが切り替わるように）
        AnimatorStateInfo stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);

        // アニメーションの長さだけ待機
        yield return new WaitForSeconds(stateInfo.length);

        // アニメーション終了
        m_animator.SetBool(m_boolParameterName, false);
    }
}
