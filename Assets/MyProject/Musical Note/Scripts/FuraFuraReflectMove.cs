using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FuraFuraReflectMove : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 5f;       // �O�i�X�s�[�h
    [SerializeField] private float m_waveAmplitude = 1f;   // �ӂ�ӂ�̕�
    [SerializeField] private float m_waveFrequency = 2f;   // �ӂ�ӂ�̑���
    [SerializeField] private Note_Move m_noteMove;

    private Rigidbody m_rigidbody;
    private Vector3 m_moveDir;     // ���݂̐i�s����
    private float m_startTime;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.useGravity = false; // �󒆈ړ����ۂ�����i��������Ȃ�true�ł�OK�j
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation; // ��]���Œ�

        m_moveDir = m_noteMove.CurrentDirection; // �����i�s����
        m_startTime = Time.time;
    }

    private void FixedUpdate()
    {
        // ���Ԃɉ����Đi�s�����������ӂ�ӂ炳����
        Vector3 wave = transform.right * Mathf.Sin((Time.time - m_startTime) * m_waveFrequency) * m_waveAmplitude * 0.1f;

        // ���ۂ̐i�s����
        Vector3 currentDir = (m_moveDir + wave).normalized;

        // Rigidbody�ňړ�
        m_rigidbody.MovePosition(transform.position + currentDir * m_moveSpeed * Time.fixedDeltaTime);

        // �������i�s�����ɍ��킹��
        transform.forward = Vector3.Lerp(transform.forward, currentDir, 0.1f);
    }

    // �����ɏՓ˂����Ƃ��ɌĂ΂��
    private void OnCollisionEnter(Collision collision)
    {
        // ���˕������v�Z
        Vector3 reflectDir = Vector3.Reflect(m_moveDir, collision.contacts[0].normal);
        m_moveDir = reflectDir.normalized;
    }

    public void ReceiveDir(Vector3 receiveDir)
    {
        m_moveDir = receiveDir;
    }
}
