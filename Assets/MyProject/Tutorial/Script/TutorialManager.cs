using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_desireObject;

    [SerializeField]
    private GameObject m_musicalNote;

    [SerializeField] 
    private Vector3 m_offsetOfDesire = Vector3.zero;

    private Note_Move m_noteMove;

    private Vector3 m_desirePosition = Vector3.zero;

    void Start()
    {
        StartTutorial();
    }

    private void StartTutorial()
    {
        GameObject obj = Instantiate(m_musicalNote, transform.localPosition, m_musicalNote.transform.rotation);
        m_noteMove = obj.GetComponent<Note_Move>();
        Vector3 P1Position = m_desireObject.transform.localPosition;
        m_desirePosition = P1Position - transform.localPosition;
        m_desirePosition += m_offsetOfDesire;
        m_noteMove.SetNoteDirection(m_desirePosition);
    }
}
