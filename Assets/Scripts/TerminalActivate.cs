using UnityEngine;
using TMPro;

public class TerminalActivate : MonoBehaviour
{
    bool activated = false;
    bool playerNear = false;

    public TMP_Text popupText;
    public GameObject targetLaser;

    void Start()
    {
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

        popupText.text = "TERMINAL ACTIVATED";

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

            if (!activated)
            {
                if (MobileUI.instance != null)
                {
                    MobileUI.instance.ShowInteractButton();
                }
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
        popupText.text = "";
    }
}