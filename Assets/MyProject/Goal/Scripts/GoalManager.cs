using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_goalObject;

    [SerializeField]
    private GameObject m_musicalNote;

    [SerializeField]
    private Vector3 m_offsetOfDesire = Vector3.zero;

    [SerializeField]
    private GameObject m_sedGoal;



    private Note_Move m_noteMove;

    private Vector3 m_goalPosition = Vector3.zero;

    bool m_isGoal = false;

    private Vector3 m_desirePosition = Vector3.zero;

    private float m_timer = 0f;

    private void Update()
    {
        if(m_musicalNote.transform.position.x >= m_goalObject.transform.position.x)
        {
            m_musicalNote.SetActive(false);
            m_sedGoal.SetActive(false);
            
        }
        if (!m_sedGoal.activeSelf) 
        {
            m_timer += Time.deltaTime;
            if (m_timer >= 3f)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!m_isGoal)
        {
            m_isGoal = true;
            m_noteMove = m_musicalNote.GetComponent<Note_Move>();
            Vector3 GoalPosition = m_goalObject.transform.localPosition;
            m_desirePosition = GoalPosition - m_musicalNote.transform.position;
            m_desirePosition += m_offsetOfDesire;
            m_noteMove.SetNoteDirection(m_desirePosition);
        }
    }
}
