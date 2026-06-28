using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public AudioSource bgm;
    public TMP_Text musicText;

    private bool musicOn = true;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu FPC");
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        bgm.mute = !musicOn;

        musicText.text = musicOn
            ? "MUSIC : ON"
            : "MUSIC : OFF";
    }
}