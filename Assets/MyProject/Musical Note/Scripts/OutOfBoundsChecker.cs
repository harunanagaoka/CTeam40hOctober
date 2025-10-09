using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundsChecker : MonoBehaviour
{
    private MeshRenderer m_renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!m_renderer.isVisible)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
