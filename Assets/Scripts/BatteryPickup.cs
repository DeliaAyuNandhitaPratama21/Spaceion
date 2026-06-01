using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    bool pickedUp = false;
    bool playerNear = false;

    void Start()
    {
        if (MobileUI.instance != null)
        {
            MobileUI.instance.HideInteractButton();
        }
    }

    public void Interact()
    {
        if (!playerNear || pickedUp)
            return;

        if (GameManager.instance.batteryCount >= 3)
            return;

        pickedUp = true;

        GameManager.instance.AddBattery();

        if (MobileUI.instance != null)
        {
            MobileUI.instance.HideInteractButton();
        }

        gameObject.SetActive(false);

        Debug.Log("Battery Picked!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (MobileUI.instance != null)
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
}