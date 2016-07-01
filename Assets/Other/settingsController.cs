using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class settingsController : MonoBehaviour {
    public Toggle[] inputMode = new Toggle[3];

    private Settings settings;
    private Game game;

    void Awake() {
        settings = FindObjectOfType<Settings>();
        game = FindObjectOfType<Game>();
    }
	
	public void setInputModeButtons() { settings.selectedInput = Settings.InputMode.BUTTONS; }
    public void setInputModeTap() { settings.selectedInput = Settings.InputMode.TOUCH_TAP; }
    public void setInputModeSwipe() { settings.selectedInput = Settings.InputMode.TOUCH_SWIPE; }
    public void saveSettings() { settings.saveSettings(); }

    public void buttonSettings() {
        if(gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
            game.deactivatePause();
        }
        else {
            gameObject.SetActive(true);
            game.activatePause();
            updateSettings();
        }
    }

    private void updateSettings() {
        if (settings.selectedInput == Settings.InputMode.BUTTONS) inputMode[0].isOn = true;
        else if (settings.selectedInput == Settings.InputMode.TOUCH_TAP) inputMode[1].isOn = true;
        else if (settings.selectedInput == Settings.InputMode.TOUCH_SWIPE) inputMode[2].isOn = true;
    }
}
