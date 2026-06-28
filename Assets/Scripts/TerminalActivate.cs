using UnityEngine;
using TMPro;

public class TerminalActivate : MonoBehaviour
{
    bool activated = false;
    bool playerNear = false;

    public GameObject TerminalActivatedText;
    public TMP_Text PopupText;
    public GameObject targetLaser;

    void Start()
    {
        TerminalActivatedText.SetActive(false);

        if (MobileUI.instance != null)
        {
            MobileUI.instance.HideInteractButton();
        }
    }

    public void Interact()
    {
        if (!playerNear || activated)
            return;

        activated = true;

        TerminalActivatedText.SetActive(true);
        PopupText.text = "TERMINAL ACTIVATED";

        if (targetLaser != null)
        {
            targetLaser.SetActive(false);
        }

        if (MobileUI.instance != null)
        {
            MobileUI.instance.HideInteractButton();
        }

        Invoke(nameof(HidePopup), 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!activated && MobileUI.instance != null)
            {
                MobileUI.instance.ShowInteractButton();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (MobileUI.instance != null)
            {
                MobileUI.instance.HideInteractButton();
            }
        }
    }

    void HidePopup()
    {
        TerminalActivatedText.SetActive(false);
    }
}