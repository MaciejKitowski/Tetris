using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour
{
    public enum Col { GREEN, RED, BLUE, MAGENTA };
    public Col color;
    public bool onArena = false;

    public void randColor()
    {
        color = (Col)Random.Range(0, 4);
        setColor();
    }

    private void setColor()
    {
        foreach(Transform obj in transform)
        {
            if (color == Col.GREEN) obj.GetComponent<SpriteRenderer>().color = Color.green;
            else if (color == Col.RED) obj.GetComponent<SpriteRenderer>().color = Color.red;
            else if (color == Col.BLUE) obj.GetComponent<SpriteRenderer>().color = Color.blue;
            else if (color == Col.MAGENTA) obj.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
}
