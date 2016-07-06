using UnityEngine;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour {
    public enum InputMode { TOUCH_TAP, TOUCH_SWIPE, BUTTONS }

    public static InputMode selectedInput = InputMode.BUTTONS;
    public static bool music, sounds;

    public Toggle[] inputMode = new Toggle[3];
    public Toggle musicCheckmark, soundsCheckmark;

    private InputButton buttonsInput;
    private InputTap tapInput;
    private InputSwipe swipeInput;
    private Animation anim;

    void Awake() {
        load();
        buttonsInput = FindObjectOfType<InputButton>();
        tapInput = FindObjectOfType<InputTap>();
        swipeInput = FindObjectOfType<InputSwipe>();
        anim = GetComponent<Animation>();
        updateInputMode();
    }

    public void buttonSettings() {
        if (gameObject.activeInHierarchy) deactivateAnimated();
        else activate();
    }

    public void setInputModeButtons() { selectedInput = Settings.InputMode.BUTTONS; }
    public void setInputModeTap() { selectedInput = Settings.InputMode.TOUCH_TAP; }
    public void setInputModeSwipe() { selectedInput = Settings.InputMode.TOUCH_SWIPE; }
    public void setMusic() { music = musicCheckmark.isOn; }
    public void setSounds() { sounds = soundsCheckmark.isOn; }
    public bool isActive() { return gameObject.activeInHierarchy; }

    public void activate() {
        gameObject.SetActive(true);
        GamePause.activate();
        anim.Play("SettingsDisplay");
        updateCheckmarks();
    }

    public void deactivate() { //Used in SettingsHide animation
        gameObject.SetActive(false);
        updateCheckmarks();
        updateInputMode();
        save();
    }

    public void deactivateAnimated() {
        anim.Play("SettingsHide");
        GamePause.deactivateAnimated();
    }

    private void save() {
        PlayerPrefs.SetInt("Input_mode", (int)selectedInput);
        PlayerPrefs.SetInt("Music", Convert.ToInt16(music));
        PlayerPrefs.SetInt("Sounds", Convert.ToInt16(sounds));
    }

    private void load() {
        selectedInput = (InputMode)PlayerPrefs.GetInt("Input_mode");
        music = Convert.ToBoolean(PlayerPrefs.GetInt("Music"));
        sounds = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds"));
    }

    private void updateCheckmarks() {
        if (selectedInput == Settings.InputMode.BUTTONS) inputMode[0].isOn = true;
        else if (selectedInput == Settings.InputMode.TOUCH_TAP) inputMode[1].isOn = true;
        else if (selectedInput == Settings.InputMode.TOUCH_SWIPE) inputMode[2].isOn = true;
        musicCheckmark.isOn = music;
        soundsCheckmark.isOn = sounds;
    }

    private void updateInputMode() {
        switch(selectedInput) {
            case InputMode.BUTTONS:
                buttonsInput.actvate();
                tapInput.deactivate();
                swipeInput.deactivate();
                break;
            case InputMode.TOUCH_TAP:
                tapInput.activate();
                buttonsInput.deactivate();
                swipeInput.deactivate();
                break;
            case InputMode.TOUCH_SWIPE:
                swipeInput.activate();
                buttonsInput.deactivate();
                tapInput.deactivate();
                break;
        }
    }
}
