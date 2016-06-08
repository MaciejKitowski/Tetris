using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    public enum InputMode { TOUCH_TAP, TOUCH_SWIPE, BUTTONS }
    public InputMode selectedInput = InputMode.BUTTONS;
}
