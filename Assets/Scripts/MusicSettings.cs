using UnityEngine;
using TMPro;

public class MusicSettings : MonoBehaviour
{
    public AudioSource bgm;
    public TMP_Text musicText;

    private bool musicOn;

    void Start()
    {
        musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        bgm.mute = !musicOn;

        UpdateText();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        bgm.mute = !musicOn;

        PlayerPrefs.SetInt("MusicOn", musicOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateText();
    }

    void UpdateText()
    {
        musicText.text = musicOn ? "MUSIC : ON" : "MUSIC : OFF";
    }
}