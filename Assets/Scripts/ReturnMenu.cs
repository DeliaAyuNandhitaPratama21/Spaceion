using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        // lanjutkan waktu game
        Time.timeScale = 1f;

        // cursor hilang lagi
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // load main menu
        SceneManager.LoadScene("MainMenu FPC");
    }
}