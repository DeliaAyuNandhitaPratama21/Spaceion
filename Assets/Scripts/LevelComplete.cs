using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject completeUI;

    void Start()
    {
        completeUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completeUI.SetActive(true);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}