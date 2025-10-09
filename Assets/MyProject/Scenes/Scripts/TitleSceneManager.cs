using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private string m_mainGameSceneName;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            SceneManager.LoadScene(m_mainGameSceneName);
        }
    }
}
