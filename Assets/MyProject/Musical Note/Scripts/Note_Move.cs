using UnityEngine;

public class Note_Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 m_direction = Vector3.left;

    // �Ώۂ̃J�����iInspector�Ŏw��A���w��Ȃ�MainCamera�j
    [SerializeField] private Camera targetCamera;
    // �J��������̋����iPerspective�p�j
    [SerializeField] private float distanceFromCamera = 10f;

    public Vector3 CurrentDirection { get { return m_direction; } private set { m_direction = value; } }

    // ����͈́i�����ƉE��j
    private Vector3 bottomLeft;
    private Vector3 topRight;

    private Vector3 m_initPos = Vector3.zero;

    void Start()
    {
        m_initPos = transform.position;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ǂɏՓ˂�����
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            Vector3 dir = Vector3.Reflect(m_direction, normal).normalized;
            m_direction = new Vector3(dir.x, 0, dir.z);
        }
        // Player�ɏՓ˂�����
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Player�̌������擾�iforward�����j
            Vector3 playerDirection = collision.gameObject.transform.forward;
            Vector3 dir = playerDirection;
            m_direction = new Vector3(dir.x, 0, dir.z);
        }
    }

    public void SetNoteDirection(Vector3 dir)
    {
        m_direction = dir.normalized;
    }
}
