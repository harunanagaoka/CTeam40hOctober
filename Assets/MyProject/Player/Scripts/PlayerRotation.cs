using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerRotation : MonoBehaviour
{
    [Header("PlayerName")]
    [SerializeField] private int m_playerName = 1; // �v���C���[��
    [Header("Rotation Settings")]
    [SerializeField] private float m_rotationSpeed = 90f;       // ��]�X�s�[�h�i�x/�b�j
    [SerializeField] private float m_maxRotationAngle = 45f;    // �ő��]�p�x�i���E�j 

    PlayerInput m_input = null;

    private float m_currentYaw = 0f;         // ���݂̊p�x
    private int m_rotateDir = 0;        // -1 = ��, 1 = �E, 0 = ��~
    

    private void Start()
    {
        if (m_playerName == 1)
        {
            m_currentYaw = 180f; // �����p�x��180�x�ɐݒ�
        }        
        
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

        // �����Ă���Ԃ����p�x�𑝌�(�v���C���[�P�̎�)
        if (m_playerName == 1)
        {
            m_currentYaw += m_rotateDir * m_rotationSpeed * Time.deltaTime;
            //m_currentYaw = Mathf.Clamp(m_currentYaw, -m_maxRotationAngle, m_maxRotationAngle);
        }
        else if (m_playerName == 2) // �v���C���[�Q�̎�
        {
            m_currentYaw += m_rotateDir * m_rotationSpeed * Time.deltaTime;
            m_currentYaw = Mathf.Clamp(m_currentYaw, -m_maxRotationAngle, m_maxRotationAngle);
        }

        // ���t���[����]��K�p
        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.y + m_currentYaw, 0f);
        
        m_rotateDir = 0;
    }
}
