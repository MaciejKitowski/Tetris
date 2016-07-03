using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
    private static bool paused = true;
    private static GameObject pauseInfo;

	void Awake() {
        pauseInfo = GameObject.FindGameObjectWithTag("Game_pause");
    }

    public static bool isPaused() { return paused; }

    public static void activate() {
        paused = true;
        pauseInfo.SetActive(true);
    }

    public static void deactivate() {
        paused = false;
        pauseInfo.SetActive(false);
    }
}
