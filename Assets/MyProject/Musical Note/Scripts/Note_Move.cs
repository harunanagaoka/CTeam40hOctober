using UnityEngine;

public class Note_Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 m_direction = Vector3.left;

    // �Ώۂ̃J�����iInspector�Ŏw��A���w��Ȃ�MainCamera�j
    [SerializeField] private Camera targetCamera;
    // �J��������̋����iPerspective�p�j
    [SerializeField] private float distanceFromCamera = 10f;

    // ����͈́i�����ƉE��j
    private Vector3 bottomLeft;
    private Vector3 topRight;

    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
        bottomLeft = targetCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceFromCamera));
        topRight   = targetCamera.ViewportToWorldPoint(new Vector3(1, 1, distanceFromCamera));
    }

    void Update()
    {
        // �������ړ�
            transform.position += m_direction * speed * Time.deltaTime;

        // Cube�̈ʒu���J�����̃r���[�|�[�g���W�ɕϊ�
        Vector3 viewportPos = targetCamera.WorldToViewportPoint(transform.position);

        // ��ʊO�Ȃ�Destroy
        if (viewportPos.x < 0f || viewportPos.x > 1f ||
            viewportPos.y < 0f || viewportPos.y > 1f)
        {
            Destroy(gameObject);
        }
    }

    // �ǂɏՓ˂������ɌĂ΂��
    private void OnCollisionEnter(Collision collision)
    {
        // �ǂɏՓ˂������Ƀ^�O�Ŕ���
        if (collision.gameObject.CompareTag("Wall")|| collision.gameObject.CompareTag("Obstacle"))
        {
            // �Փ˂����ǂ̖@�����擾
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;

            // ���˃x�N�g���i�i�s�����j�Ɩ@�����甽�˃x�N�g�����v�Z
            m_direction = Vector3.Reflect(m_direction, normal).normalized;
        }
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
