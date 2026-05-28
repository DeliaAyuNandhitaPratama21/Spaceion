using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TerminalActivate : MonoBehaviour
{
    bool activated = false;
    bool playerNear = false;

    public TMP_Text popupText;
    public GameObject pressInteractText;

    public GameObject targetLaser;

    void Start()
    {
        pressInteractText.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !activated)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                activated = true;

                popupText.text = "TERMINAL ACTIVATED";

                // matiin laser
                targetLaser.SetActive(false);

                pressInteractText.SetActive(false);

                Invoke("HidePopup", 2f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!activated)
            {
                pressInteractText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            pressInteractText.SetActive(false);
        }
    }

    void HidePopup()
    {
        popupText.text = "";
    }
}