using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FuraFuraReflectMove : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 5f;       // 前進スピード
    [SerializeField] private float m_waveAmplitude = 1f;   // ふらふらの幅
    [SerializeField] private float m_waveFrequency = 2f;   // ふらふらの速さ
    [SerializeField] private Note_Move m_noteMove;

    private Rigidbody m_rigidbody;
    private Vector3 m_moveDir;     // 現在の進行方向
    private float m_startTime;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false; // 空中移動っぽくする（床を歩くならtrueでもOK）
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation; // 回転を固定

        m_moveDir = m_noteMove.CurrentDirection; // 初期進行方向
        m_startTime = Time.time;
    }

    private void FixedUpdate()
    {
        // 時間に応じて進行方向を少しふらふらさせる
        Vector3 wave = transform.right * Mathf.Sin((Time.time - m_startTime) * m_waveFrequency) * m_waveAmplitude * 0.1f;

        // 実際の進行方向
        Vector3 currentDir = (m_moveDir + wave).normalized;

        // Rigidbodyで移動
        m_rigidbody.MovePosition(transform.position + currentDir * m_moveSpeed * Time.fixedDeltaTime);

        // 向きも進行方向に合わせる
        transform.forward = Vector3.Lerp(transform.forward, currentDir, 0.1f);
    }

    // 何かに衝突したときに呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        // 反射方向を計算
        Vector3 reflectDir = Vector3.Reflect(m_moveDir, collision.contacts[0].normal);
        m_moveDir = reflectDir.normalized;
    }

    public void ReceiveDir(Vector3 receiveDir)
    {
        m_moveDir = receiveDir;
    }
}
