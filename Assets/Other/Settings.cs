using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour {
    public enum InputMode { TOUCH_TAP, TOUCH_SWIPE, BUTTONS }

    public InputMode selectedInput = InputMode.BUTTONS;
    public bool music, sounds;
    public Toggle[] inputMode = new Toggle[3];
    public Toggle musicCheckmark, soundsCheckmark;

    private Game game;

    void Awake() {
        loadSettings();
        game = FindObjectOfType<Game>();
    }

    public void loadSettings() {
        selectedInput = (InputMode)PlayerPrefs.GetInt("Input_mode");
        music = Convert.ToBoolean(PlayerPrefs.GetInt("Music"));
        sounds = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds"));
    }

    public void saveSettings() {
        PlayerPrefs.SetInt("Input_mode", (int)selectedInput);
        PlayerPrefs.SetInt("Music", Convert.ToInt16(music));
        PlayerPrefs.SetInt("Sounds", Convert.ToInt16(sounds));
    }

    public void buttonSettings() {
        if (gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
            game.deactivatePause();
            saveSettings();
        }
        else {
            gameObject.SetActive(true);
            game.activatePause();
            updateSettings();
        }
    }

    public void setInputModeButtons() { selectedInput = Settings.InputMode.BUTTONS; }
    public void setInputModeTap() { selectedInput = Settings.InputMode.TOUCH_TAP; }
    public void setInputModeSwipe() { selectedInput = Settings.InputMode.TOUCH_SWIPE; }
    public void setMusic() { music = musicCheckmark.isOn; }
    public void setSounds() { sounds = soundsCheckmark.isOn; }

    private void updateSettings() {
        if (selectedInput == Settings.InputMode.BUTTONS) inputMode[0].isOn = true;
        else if (selectedInput == Settings.InputMode.TOUCH_TAP) inputMode[1].isOn = true;
        else if (selectedInput == Settings.InputMode.TOUCH_SWIPE) inputMode[2].isOn = true;
        musicCheckmark.isOn = music;
        soundsCheckmark.isOn = sounds;
    }
}
