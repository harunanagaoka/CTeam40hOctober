using UnityEngine;

public class Map_Move : MonoBehaviour
{
    // ���ړ��t���O
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
        // a�L�[�������ꂽ�u�ԂɃt���O��ON
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_isMovingLeft = true;
        }

        // �t���O��ON�Ȃ獶�Ɉړ���������
        if (m_isMovingLeft)
        {
            transform.position += Vector3.left * m_moveSpeed * Time.deltaTime;
        }
    }
}
