using UnityEngine;

public class MoveModeSwitcher : MonoBehaviour
{
    [SerializeField] private MonoBehaviour m_normalMove;        // NoteMove
    [SerializeField] private MonoBehaviour m_furaFuraMove;      // FuraFuraReflectMove
    [SerializeField] private string m_furaFuraTag = "Cymbal";  // ふらふら化する障害物のタグ
    [SerializeField] private FuraFuraReflectMove m_furaFuraReflectMove;
    [SerializeField] private Note_Move m_noteMove;

    private void Start()
    {
        // 初期状態：通常移動オン、ふらふらオフ
        if (m_normalMove != null) m_normalMove.enabled = true;
        if (m_furaFuraMove != null) m_furaFuraMove.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(m_furaFuraTag))
        {
            Vector3 noteMove = m_noteMove.CurrentDirection;
            m_furaFuraReflectMove.ReceiveDir(noteMove);

            // 特定の障害物に当たったらふらふらモードへ
            if (m_normalMove != null) m_normalMove.enabled = false;
            if (m_furaFuraMove != null) m_furaFuraMove.enabled = true;

            Debug.Log("ふらふらモードに切り替え");
        }
        else
        {
            // それ以外のタグに当たったら通常モードに戻す
            if (m_normalMove != null) m_normalMove.enabled = true;
            if (m_furaFuraMove != null) m_furaFuraMove.enabled = false;

            Debug.Log("通常モードに戻す");
        }
    }
}
