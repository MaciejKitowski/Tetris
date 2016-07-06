using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    public static int activeLevel = 1;
    public static int pointsToChangeLevel = 3;
    public static float speedChange = 0.05f;

    private static Text txt;

    void Awake() { txt = transform.GetChild(1).GetComponent<Text>(); }

    public static void updateText() {
        txt.text = activeLevel.ToString();
    }

    public static void reset() {
        activeLevel = 1;
        pointsToChangeLevel = 3;
        updateText();
    }

    public static void newLevel() {
        activeLevel += 1;
        pointsToChangeLevel = 3;
        updateText();
    }

    public static void achievedPoints() {
        --pointsToChangeLevel;
        if (pointsToChangeLevel == 0) newLevel();
    }

    public static float getSpeedChange() {
        if (activeLevel <= 10) return (activeLevel - 1) * speedChange;
        else return speedChange * 10;
    }
}
