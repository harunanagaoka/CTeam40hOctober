using UnityEngine;
using UnityEngine.InputSystem;

public class P1Controller : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] private float m_playerMoveSpeed = 1f;

    private Vector3 m_velocity;

    // �ʒm���󂯎�郁�\�b�h���́uOn + Action���v�ł���K�v������
    private void OnMove(InputValue value)
    {
        // MoveAction�̓��͒l���擾
        var axis = value.Get<Vector2>();

        // �ړ����x��ێ�
        m_velocity = new Vector3(axis.x, 0, 0);
    }

    private void Update()
    {
        // �I�u�W�F�N�g�ړ�
        transform.position += m_playerMoveSpeed * m_velocity * Time.deltaTime;
    }
}

