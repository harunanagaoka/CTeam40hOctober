using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float m_rotationSpeed = 90f;       // ��]�X�s�[�h�i�x/�b�j
    [SerializeField] private float m_maxRotationAngle = 45f;    // �ő��]�p�x�i���E�j
    PlayerInput m_input = null;

    private int m_rotateDir = 0;        // -1 = ��, 1 = �E, 0 = ��~
    private float m_currentYaw = 0f;    // ���݂̉�]�p�x

    private void Start()
    {
        m_input = GetComponent<PlayerInput>();
    }

    private void Update()
    {

        if (m_input.actions["LeftLook"].IsPressed())
        {
            m_rotateDir = -1;
        }
        if (m_input.actions["RightLook"].IsPressed())
        {
            m_rotateDir = 1;
        }

        // �����Ă���Ԃ����p�x�𑝌�
        m_currentYaw += m_rotateDir * m_rotationSpeed * Time.deltaTime;
        m_currentYaw = Mathf.Clamp(m_currentYaw, -m_maxRotationAngle, m_maxRotationAngle);


        // ���t���[����]��K�p
        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.y + m_currentYaw, 0f);
        
        m_rotateDir = 0;
    }
}
