using UnityEngine;
using System.Collections;

public class arenaTileController : MonoBehaviour
{
    public int posX, posY;
    public bool isEmpty = true;

    void Awake()
    {
        //Get tile position from name
        char[] splitChars = { '(', ',', ')' };
        string[] buffer = transform.name.Split(splitChars);
        posX = int.Parse(buffer[1]);
        posY = int.Parse(buffer[2]);
    }

    void OnCollisionEnter2D(Collision2D obj) { isEmpty = false; }
    void OnCollisionExit2D(Collision2D obj) { isEmpty = true; }
}
