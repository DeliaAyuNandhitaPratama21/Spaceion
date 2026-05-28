using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int batteryCount = 0;

    public TextMeshProUGUI batteryText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateBatteryUI();
    }

    public void AddBattery()
    {
        // maksimal 3
        if (batteryCount >= 3)
        {
            return;
        }

        batteryCount++;

        UpdateBatteryUI();
    }

    public void UpdateBatteryUI()
    {
        batteryText.text = "Battery : " + batteryCount + " / 3";
    }
}