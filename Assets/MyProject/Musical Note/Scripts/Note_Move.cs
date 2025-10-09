using UnityEngine;
using UnityEngine.SceneManagement;

public class Note_Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 m_direction = Vector3.left;

    // 対象のカメラ（Inspectorで指定可、未指定ならMainCamera）
    [SerializeField] private Camera targetCamera;
    // カメラからの距離（Perspective用）
    [SerializeField] private float distanceFromCamera = 10f;

    public Vector3 CurrentDirection { get { return m_direction; } private set { m_direction = value; } }

    // 視野範囲（左下と右上）
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
        // 音符を移動

            transform.position += m_direction * speed * Time.deltaTime;


        // Cubeの位置をカメラのビューポート座標に変換
        Vector3 viewportPos = targetCamera.WorldToViewportPoint(transform.position);

        //// 画面外ならDestroy
        //if (viewportPos.x < 0f || viewportPos.x > 1f ||
        //    viewportPos.y < 0f || viewportPos.y > 1f)
        //{
        //    SceneManager.LoadScene("TitleScene");
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 壁に衝突した時
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            m_direction = Vector3.Reflect(m_direction, normal).normalized;
        }
        // Playerに衝突した時
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Playerの向きを取得（forward方向）
            Vector3 playerDirection = collision.gameObject.transform.forward;
            m_direction = playerDirection;
        }
    }

    public void SetNoteDirection(Vector3 dir)
    {
        m_direction = dir.normalized;
    }
}
