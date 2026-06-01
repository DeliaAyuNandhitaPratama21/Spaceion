using UnityEngine;
using StarterAssets;

public class MobileInputBridge : MonoBehaviour
{
    public FixedJoystick joystick;

    private StarterAssetsInputs input;

    void Start()
    {
        input = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update()
    {
        if (input != null)
        {
            input.move = new Vector2(
                joystick.Horizontal,
                joystick.Vertical
            );
        }
    }
}