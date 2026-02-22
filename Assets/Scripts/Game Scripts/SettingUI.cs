using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    public Slider lookSlider;
    public TextMeshProUGUI lookValueText;

    void Start()
    {
        float value = SettingsManager.Instance.lookSensitivity;

        lookSlider.value = value;
        UpdateText(value);

        lookSlider.onValueChanged.AddListener(OnLookSliderChanged);
    }

    public void OnLookSliderChanged(float value)
    {
        SettingsManager.Instance.SetLookSensitivity(value);
        UpdateText(value);
    }

    void UpdateText(float value)
    {
        if (lookValueText != null)
            lookValueText.text = Mathf.RoundToInt(value).ToString();
    }
}