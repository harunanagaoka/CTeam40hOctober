using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_desireObject;

    [SerializeField]
    private GameObject m_musicalPrefab;

    [SerializeField]
    private Vector3 m_offsetOfDesire = Vector3.zero;

    private GoalManager m_goal;

    private GoalManager m_goalManagaer;

    private Note_Move m_noteMove;

    private Vector3 m_desirePosition = Vector3.zero;

    void Start()
    {
        GameObject goal = GameObject.Find("GoalManager");
        m_goalManagaer = goal.GetComponent<GoalManager>();
        StartTutorial();
    }

    private void StartTutorial()
    {
        Vector3 appearPos = transform.position;
        appearPos.y = 0.906f;
        GameObject obj = Instantiate(m_musicalPrefab, appearPos, m_musicalPrefab.transform.rotation);
        m_goalManagaer.AddNoteObject(obj);
        m_noteMove = obj.GetComponent<Note_Move>();
        Vector3 P1Position = m_desireObject.transform.position;
        m_desirePosition = P1Position - transform.position;
        m_desirePosition += m_offsetOfDesire;
        m_noteMove.SetNoteDirection(m_desirePosition);
    }
}