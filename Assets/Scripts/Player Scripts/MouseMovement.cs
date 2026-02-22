using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float baseMouseSensitivity = 3f;
    public float baseMobileSensitivity = 0.08f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
#if UNITY_STANDALONE || UNITY_WEBGL
        Cursor.lockState = CursorLockMode.Locked;
#endif
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBGL

        if (MenuManager.Instance != null && MenuManager.Instance.IsMenuOpen)
            return;

        float mouseX = Input.GetAxis("Mouse X") *
               SettingsManager.Instance.GetMouseSensitivity(baseMouseSensitivity);
        float mouseY = Input.GetAxis("Mouse Y") *
               SettingsManager.Instance.GetMouseSensitivity(baseMouseSensitivity);

        Look(mouseX, mouseY);

#endif
    }

    public void Look(float xInput, float yInput)
    {
        xRotation -= yInput;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += xInput;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    public float GetMobileSensitivity()
    {
        float multiplier = SettingsManager.Instance.GetLookMultiplier();
        return baseMobileSensitivity * multiplier;
    }
}