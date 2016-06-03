using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pointsCounter : MonoBehaviour
{
    private int pointsVal = 0;
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        text.text = pointsVal.ToString();
    }

    public void addPoints(int val)
    {
        pointsVal += val;
        text.text = pointsVal.ToString();
    }
}
