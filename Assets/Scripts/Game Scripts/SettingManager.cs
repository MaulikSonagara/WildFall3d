using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    private const string LOOK_KEY = "LOOK_SENSITIVITY";
    private const string SFX_KEY = "SFX_VOLUME";
    private const string MUSIC_KEY = "MUSIC_VOLUME";

    [Header("Controls")]
    [Range(0, 100)] public float lookSensitivity = 50f;

    [Header("Audio")]
    [Range(0, 1)] public float sfxVolume = 1f;
    [Range(0, 1)] public float musicVolume = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region LOAD / SAVE

    void LoadAllSettings()
    {
        lookSensitivity = PlayerPrefs.GetFloat(LOOK_KEY, 50f);
        sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
    }

    void Save()
    {
        PlayerPrefs.SetFloat(LOOK_KEY, lookSensitivity);
        PlayerPrefs.SetFloat(SFX_KEY, sfxVolume);
        PlayerPrefs.SetFloat(MUSIC_KEY, musicVolume);
        PlayerPrefs.Save();
    }

    #endregion

    #region LOOK SENSITIVITY

    public void SetLookSensitivity(float value)
    {
        lookSensitivity = value;
        Save();
    }

    public float GetLookMultiplier()
    {
        return lookSensitivity / 100f;
    }

    #endregion

    #region AUDIO (FOR LATER)

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        Save();
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        Save();
    }

    #endregion

    #region PLATFORM INDEPENDENT SENSITIVITY VALUES

    public float GetMouseSensitivity(float baseValue)
    {
        return baseValue * GetLookMultiplier();
    }

    public float GetMobileSensitivity(float baseValue)
    {
        return baseValue * GetLookMultiplier();
    }

    #endregion
}