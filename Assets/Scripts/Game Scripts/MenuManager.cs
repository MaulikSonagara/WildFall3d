using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject settingsMenu;

    public bool IsMenuOpen { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBGL

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }

#endif
    }

    public void ToggleSettings()
    {
        if (settingsMenu.activeSelf)
            CloseMenu();
        else
            OpenMenu(settingsMenu);
    }

    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
        IsMenuOpen = true;

        ApplyCursorState();
    }

    public void CloseMenu()
    {
        settingsMenu.SetActive(false);
        IsMenuOpen = false;

        ApplyCursorState();
    }

    void ApplyCursorState()
    {
#if UNITY_STANDALONE || UNITY_WEBGL

        if (IsMenuOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

#endif
    }
}