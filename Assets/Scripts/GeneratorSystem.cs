using UnityEngine;
using UnityEngine.InputSystem;

public class GeneratorSystem : MonoBehaviour
{
    public Animator doorAnim;

    public GameObject generatorBattery1;
    public GameObject generatorBattery2;
    public GameObject generatorBattery3;

    public GameObject pressInteractText;

    // drag cube merah / GeneratorTrigger ke sini
    public Renderer indicatorRenderer;

    int batteryInserted = 0;

    bool activated = false;

    bool playerNear = false;

    bool canInsert = true;

    void Start()
    {
        generatorBattery1.SetActive(false);
        generatorBattery2.SetActive(false);
        generatorBattery3.SetActive(false);

        pressInteractText.SetActive(false);

        // warna awal merah
        if (indicatorRenderer != null)
        {
            indicatorRenderer.material.color = Color.red;
        }
    }

    void Update()
    {
        if (playerNear && !activated)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && canInsert)
            {
                if (GameManager.instance.batteryCount > 0)
                {
                    canInsert = false;

                    InsertBattery();

                    Invoke(nameof(ResetInsert), 0.2f);
                }
            }
        }
    }

    void ResetInsert()
    {
        canInsert = true;
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

    void InsertBattery()
    {
        if (batteryInserted >= 3)
        {
            return;
        }

        batteryInserted++;

        GameManager.instance.batteryCount--;

        GameManager.instance.UpdateBatteryUI();

        Debug.Log("Battery Inserted!");

        if (batteryInserted == 1)
        {
            generatorBattery1.SetActive(true);
        }

        if (batteryInserted == 2)
        {
            generatorBattery2.SetActive(true);
        }

        if (batteryInserted == 3)
        {
            generatorBattery3.SetActive(true);

            ActivateGenerator();
        }
    }

    void ActivateGenerator()
    {
        activated = true;

        Debug.Log("Generator Active!");

        // jadi hijau
        if (indicatorRenderer != null)
        {
            indicatorRenderer.material.color = Color.green;
        }

        pressInteractText.SetActive(false);

        if (doorAnim != null)
        {
            doorAnim.CrossFade("door_2_open", 0f);
        }
    }
}