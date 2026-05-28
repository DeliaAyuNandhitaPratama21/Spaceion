using UnityEngine;

public class GameManagerLevel2 : MonoBehaviour
{
    public static GameManagerLevel2 instance;

    public int terminalActivated = 0;

    void Awake()
    {
        instance = this;
    }

    public void ActivateTerminal()
    {
        terminalActivated++;

        Debug.Log("Terminal Active: " + terminalActivated);

        if (terminalActivated >= 2)
        {
            Debug.Log("All Terminal Activated!");
        }
    }
}