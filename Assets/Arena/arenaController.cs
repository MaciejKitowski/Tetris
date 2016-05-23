using UnityEngine;
using System.Collections;

public class arenaController : MonoBehaviour
{
    public GameObject[,] arenaTile = new GameObject[10, 20];
    public bool displayLogs = true;

    void Awake()
    {
        char[] splitChars = { '(', ',', ')' };

        for (int y = 0; y < 20; ++y)
        {
            foreach (Transform obj in transform.GetChild(y).gameObject.transform)
            {
                string[] buffer = obj.name.Split(splitChars);

                arenaTile[int.Parse(buffer[1]), y] = obj.gameObject;
                if(Debug.isDebugBuild && displayLogs) Debug.Log("ArenaController - " + arenaTile[int.Parse(buffer[1]), y].name + " set to arenaTile[" + int.Parse(buffer[1]) + "," + y + "]");
            }
        }
    }
}
