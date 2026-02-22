using UnityEngine;
using UnityEngine.EventSystems;

public class MobileLookPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public MouseMovement cameraLook;

    private Vector2 lastPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        lastPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (MenuManager.Instance != null && MenuManager.Instance.IsMenuOpen)
            return;

        Vector2 delta = eventData.position - lastPos;
        lastPos = eventData.position;

        // Get final sensitivity from MouseMovement (which uses SettingsManager SSOT)
        float sensitivity = cameraLook.GetMobileSensitivity();

        float lookX = delta.x * sensitivity * 10;
        float lookY = delta.y * sensitivity * 10;

        cameraLook.Look(lookX, lookY);
    }
}