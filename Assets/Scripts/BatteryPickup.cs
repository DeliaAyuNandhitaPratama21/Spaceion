using UnityEngine;
using UnityEngine.InputSystem;

public class BatteryPickup : MonoBehaviour
{
    public GameObject pressInteractText;

    bool pickedUp = false;

    bool playerNear = false;

    void Start()
    {
        pressInteractText.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !pickedUp)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                // maksimal 3 battery
                if (GameManager.instance.batteryCount >= 3)
                {
                    return;
                }

                pickedUp = true;

                GameManager.instance.AddBattery();

                pressInteractText.SetActive(false);

                gameObject.SetActive(false);

                Debug.Log("Battery Picked!");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            pressInteractText.SetActive(true);
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
}