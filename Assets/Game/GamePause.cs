using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
    private static bool paused = true;
    private static GameObject pauseInfo;
    private static Animation anim;

	void Awake() {
        pauseInfo = gameObject;
        anim = pauseInfo.GetComponent<Animation>();
    }

    public static bool isPaused() { return paused; }

    public static void activate() {
        paused = true;
        pauseInfo.SetActive(true);
        anim.Play("PauseDisplay");
    }

    public static void deactivateAnimated() { anim.Play("PauseHide"); }

    public void deactivate() {   //Used in PauseHide animation
        paused = false;
        pauseInfo.SetActive(false);
    }

}
