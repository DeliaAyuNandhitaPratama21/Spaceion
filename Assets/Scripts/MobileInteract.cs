using UnityEngine;

public class MobileInteract : MonoBehaviour
{
    public BatteryPickup battery1;
    public BatteryPickup battery2;
    public BatteryPickup battery3;

    public TerminalActivate terminal1;
    public TerminalActivate terminal2;

    public GeneratorSystem generator;

    public void Interact()
    {
        if (battery1 != null) battery1.Interact();
        if (battery2 != null) battery2.Interact();
        if (battery3 != null) battery3.Interact();

        if (terminal1 != null) terminal1.Interact();
        if (terminal2 != null) terminal2.Interact();

        if (generator != null) generator.Interact();
    }
}