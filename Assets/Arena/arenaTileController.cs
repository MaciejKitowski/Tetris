using UnityEngine;
using System.Collections;

public class arenaTileController : MonoBehaviour
{
    public int posX, posY;

    void Awake()
    {
        //Get tile position from name
        char[] splitChars = { '(', ',', ')' };
        string[] buffer = transform.name.Split(splitChars);
        posX = int.Parse(buffer[1]);
        posY = int.Parse(buffer[2]);
    }
}
