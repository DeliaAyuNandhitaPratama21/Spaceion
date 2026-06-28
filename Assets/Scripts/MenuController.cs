using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("Level1 FPC");
    }
}