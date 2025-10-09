using UnityEngine;

public class Map_Move : MonoBehaviour
{
    // 左移動フラグ
    [SerializeField]
    private bool m_isMovingLeft = true;

    [SerializeField]
    private float m_moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // aキーが押された瞬間にフラグをON
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_isMovingLeft = true;
        }

        // フラグがONなら左に移動し続ける
        if (m_isMovingLeft)
        {
            transform.position += Vector3.left * m_moveSpeed * Time.deltaTime;
        }
    }
}
