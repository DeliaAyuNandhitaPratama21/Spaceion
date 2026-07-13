using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class MobileLook : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [Header("Look Settings")]
    public float sensitivity = 0.6f;

    private StarterAssetsInputs input;
    private bool dragging = false;

    void Start()
    {
        input = FindFirstObjectByType<StarterAssetsInputs>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (input == null) return;

        input.look = eventData.delta * sensitivity;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;

        if (input != null)
            input.look = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!dragging && input != null)
        {
            input.look = Vector2.zero;
        }
    }
}