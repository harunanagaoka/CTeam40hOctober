using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerRotation : MonoBehaviour
{
    [Header("PlayerName")]
    [SerializeField] private int m_playerName = 1; // プレイヤー名
    [Header("Rotation Settings")]
    [SerializeField] private float m_rotationSpeed = 90f;       // 回転スピード（度/秒）
    [SerializeField] private float m_maxRotationAngle = 45f;    // 最大回転角度（左右） 

    PlayerInput m_input = null;

    private float m_currentYaw = 0f;         // 現在の角度
    private int m_rotateDir = 0;        // -1 = 左, 1 = 右, 0 = 停止
    

    private void Start()
    {
        if (m_playerName == 1)
        {
            m_currentYaw = 180f; // 初期角度を180度に設定
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

        // 押している間だけ角度を増減(プレイヤー１の時)
        if (m_playerName == 1)
        {
            m_currentYaw += m_rotateDir * m_rotationSpeed * Time.deltaTime;
            //m_currentYaw = Mathf.Clamp(m_currentYaw, -m_maxRotationAngle, m_maxRotationAngle);
        }
        else if (m_playerName == 2) // プレイヤー２の時
        {
            m_currentYaw += m_rotateDir * m_rotationSpeed * Time.deltaTime;
            m_currentYaw = Mathf.Clamp(m_currentYaw, -m_maxRotationAngle, m_maxRotationAngle);
        }

        // 毎フレーム回転を適用
        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.y + m_currentYaw, 0f);
        
        m_rotateDir = 0;
    }
}
