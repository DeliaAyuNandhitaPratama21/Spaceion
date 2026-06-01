using UnityEngine;

public class MobileUI : MonoBehaviour
{
    public static MobileUI instance;

    public GameObject interactButton;

    void Awake()
    {
        instance = this;

        interactButton.SetActive(false);
    }

    public void ShowInteractButton()
    {
        interactButton.SetActive(true);
    }

    public void HideInteractButton()
    {
        interactButton.SetActive(false);
    }
}