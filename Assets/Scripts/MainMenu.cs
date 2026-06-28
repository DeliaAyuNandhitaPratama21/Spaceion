using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PLAY CLICKED");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Level1 FPC");
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("EXIT CLICKED");
    }
}