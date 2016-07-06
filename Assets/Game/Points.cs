using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Points : MonoBehaviour {
    private static int pointsVal = 0;
    private static Text text;

    void Awake() {
        text = GetComponent<Text>();
        text.text = pointsVal.ToString();
    }

    public static void addPoints(int val) {
        pointsVal += val * Level.activeLevel;
        text.text = pointsVal.ToString();
        Level.achievedPoints();
    }

    public static void resetPoints() {
        pointsVal = 0;
        text.text = pointsVal.ToString();
    }

    public static int getPoints() { return pointsVal; }
}
