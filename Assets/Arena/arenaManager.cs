using UnityEngine;
using System.Collections;

public class arenaManager : MonoBehaviour
{
    public arenaTileController[,] tile = new arenaTileController[10,20];

    void Awake()
    {
        char[] splitChars = { '(', ',', ')' };

        for (int y = 0; y < 20; ++y)
        {
            foreach (Transform obj in transform.GetChild(y).gameObject.transform)
            {
                string[] buffer = obj.name.Split(splitChars);
                tile[int.Parse(buffer[1]), y] = obj.gameObject.GetComponent<arenaTileController>();
            }
        }
    }
}
