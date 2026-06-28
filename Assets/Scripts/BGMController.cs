using UnityEngine;

public class BGMController : MonoBehaviour
{
    void Start()
    {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        GetComponent<AudioSource>().mute = !musicOn;
    }
}