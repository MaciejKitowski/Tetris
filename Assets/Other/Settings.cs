using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
    public enum InputMode { TOUCH_TAP, TOUCH_SWIPE, BUTTONS }
    public InputMode selectedInput = InputMode.BUTTONS;

    void Awake() { loadSettings(); }

    public void loadSettings() {
        if (PlayerPrefs.HasKey("Settings")) {
            selectedInput = (InputMode)PlayerPrefs.GetInt("Input_mode");
        }
        else saveSettings();
    }

    public void saveSettings() {
        PlayerPrefs.SetInt("Settings", 1);
        PlayerPrefs.SetInt("Input_mode", (int)selectedInput);
    }
}
