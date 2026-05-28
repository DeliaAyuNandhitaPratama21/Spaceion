using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public GameObject nextLevelUI;

    void Start()
    {
        // kalau UI belum diisi, biar gak error
        if (nextLevelUI != null)
        {
            nextLevelUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextLevelUI != null)
            {
                nextLevelUI.SetActive(true);
            }

            // pause game
            Time.timeScale = 0f;

            // munculkan cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextLevelUI != null)
            {
                nextLevelUI.SetActive(false);
            }

            // lanjut game
            Time.timeScale = 1f;

            // lock cursor lagi
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void GoToNextLevel()
    {
        // normalin time
        Time.timeScale = 1f;

        // lock cursor lagi
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene("Level2 FPC");
    }
}