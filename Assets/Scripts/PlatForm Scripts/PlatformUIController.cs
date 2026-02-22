using UnityEngine;

public class PlatformUIController : MonoBehaviour
{
    public GameObject mobileUI;   // Canvas with joystick/buttons
    public GameObject pcUI;       // Optional PC UI (crosshair etc)

    void Start()
    {
        DetectPlatform();
    }

    void DetectPlatform()
    {
#if UNITY_ANDROID || UNITY_IOS

        // Mobile build
        mobileUI.SetActive(true);
        if (pcUI != null) pcUI.SetActive(false);

#else

        // PC / WebGL build
        mobileUI.SetActive(false);
        if (pcUI != null) pcUI.SetActive(true);

#endif


        //// EXTRA SAFETY → If running WebGL on mobile browser
        //if (Input.touchSupported && Input.deviceType == DeviceType.Handheld)
        //{
        //    mobileUI.SetActive(true);
        //    if (pcUI != null) pcUI.SetActive(false);
        //}
    }
}