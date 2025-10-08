using UnityEngine;

public class MoveModeSwitcher : MonoBehaviour
{
    [SerializeField] private MonoBehaviour m_normalMove;        // NoteMove
    [SerializeField] private MonoBehaviour m_furaFuraMove;      // FuraFuraReflectMove
    [SerializeField] private string m_furaFuraTag = "Cymbal";  // �ӂ�ӂ牻�����Q���̃^�O
    [SerializeField] private FuraFuraReflectMove m_furaFuraReflectMove;
    [SerializeField] private Note_Move m_noteMove;

    private void Start()
    {
        // ������ԁF�ʏ�ړ��I���A�ӂ�ӂ�I�t
        if (m_normalMove != null) m_normalMove.enabled = true;
        if (m_furaFuraMove != null) m_furaFuraMove.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(m_furaFuraTag))
        {
            Vector3 noteMove = m_noteMove.CurrentDirection;
            m_furaFuraReflectMove.ReceiveDir(noteMove);

            // ����̏�Q���ɓ���������ӂ�ӂ烂�[�h��
            if (m_normalMove != null) m_normalMove.enabled = false;
            if (m_furaFuraMove != null) m_furaFuraMove.enabled = true;

            Debug.Log("�ӂ�ӂ烂�[�h�ɐ؂�ւ�");
        }
        else
        {
            // ����ȊO�̃^�O�ɓ���������ʏ탂�[�h�ɖ߂�
            if (m_normalMove != null) m_normalMove.enabled = true;
            if (m_furaFuraMove != null) m_furaFuraMove.enabled = false;

            Debug.Log("�ʏ탂�[�h�ɖ߂�");
        }
    }
}
