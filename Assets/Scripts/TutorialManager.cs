using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject tutorialPanel;
    public TMP_Text tutorialText;

    [Header("References")]
    public Joystick joystick;
    public Transform playerCameraRoot;

    private int currentStep = 0;
    private float startRotationY;

    void Start()
    {
        tutorialPanel.SetActive(true);

        tutorialText.text =
            "Use the joystick to move around the station.";
    }

    void Update()
    {
        // STEP 1 - Gerakkan joystick
        if (currentStep == 0)
        {
            if (Mathf.Abs(joystick.Horizontal) > 0.2f ||
                Mathf.Abs(joystick.Vertical) > 0.2f)
            {
                currentStep = 1;

                tutorialText.text =
                    "Swipe to rotate the camera.";

                startRotationY =
                    playerCameraRoot.eulerAngles.y;
            }
        }

        // STEP 2 - Putar kamera
        else if (currentStep == 1)
        {
            float currentRotation =
                playerCameraRoot.eulerAngles.y;

            float difference =
                Mathf.Abs(
                    Mathf.DeltaAngle(
                        startRotationY,
                        currentRotation
                    )
                );

            if (difference > 15f)
            {
                currentStep = 2;

                StartCoroutine(ShowObjective());
            }
        }
    }

    IEnumerator ShowObjective()
    {
        tutorialText.text =
            "Find and collect 3 batteries.";

        yield return new WaitForSeconds(2f);

        tutorialPanel.SetActive(false);
    }
}