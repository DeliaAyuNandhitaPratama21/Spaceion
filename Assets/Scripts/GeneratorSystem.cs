using UnityEngine;

public class GeneratorSystem : MonoBehaviour
{
    public Animator doorAnim;

    public GameObject generatorBattery1;
    public GameObject generatorBattery2;
    public GameObject generatorBattery3;

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

        if (indicatorRenderer != null)
        {
            indicatorRenderer.material.color = Color.red;
        }
    }

    public void Interact()
    {
        if (!playerNear || activated || !canInsert)
            return;

        if (GameManager.instance.batteryCount > 0)
        {
            canInsert = false;

            InsertBattery();

            Invoke(nameof(ResetInsert), 0.2f);
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

    void InsertBattery()
    {
        if (batteryInserted >= 3)
            return;

        batteryInserted++;

        GameManager.instance.batteryCount--;

        GameManager.instance.UpdateBatteryUI();

        if (batteryInserted == 1)
            generatorBattery1.SetActive(true);

        if (batteryInserted == 2)
            generatorBattery2.SetActive(true);

        if (batteryInserted == 3)
        {
            generatorBattery3.SetActive(true);
            ActivateGenerator();
        }
    }

    void ActivateGenerator()
    {
        activated = true;

        if (indicatorRenderer != null)
        {
            indicatorRenderer.material.color = Color.green;
        }

        if (MobileUI.instance != null)
        {
            MobileUI.instance.HideInteractButton();
        }

        if (doorAnim != null)
        {
            doorAnim.CrossFade("door_2_open", 0f);
        }
    }
}