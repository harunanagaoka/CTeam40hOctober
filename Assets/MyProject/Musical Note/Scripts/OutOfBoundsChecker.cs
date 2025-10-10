using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundsChecker : MonoBehaviour
{
    void LateUpdate()
    {
        if (IsOutOfScreen(transform.position))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    private bool IsOutOfScreen(Vector3 worldPosition)
    {
        Camera cam = Camera.main;
        Vector3 viewportPos = cam.WorldToViewportPoint(worldPosition);
        bool a = viewportPos.x < 0 || viewportPos.x > 1 ||
               viewportPos.y < 0 || viewportPos.y > 1 ||
               viewportPos.z < 0;
        // z < 0 ‚ÍƒJƒƒ‰‚ÌŒã‚ë‚É‚¢‚é
        return viewportPos.x < 0 || viewportPos.x > 1 ||
               viewportPos.y < 0 || viewportPos.y > 1 ||
               viewportPos.z < 0;
    }
}
