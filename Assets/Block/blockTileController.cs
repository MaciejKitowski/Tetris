using UnityEngine;
using System.Collections;

public class blockTileController : MonoBehaviour
{
    public enum blockColor { GREEN, RED, BLUE, MAGENTA, YELLOW, ORANGE, CYAN };

    public bool blockControllerRemoved = false;
    public arenaTileController arenaTile;
    public blockColor color = blockColor.GREEN;

    private arenaManager managerArena;

    void Start() { managerArena = FindObjectOfType<arenaManager>(); }

    void Update()
    {
        if(blockControllerRemoved && arenaTile.posY < 19 && managerArena.tile[arenaTile.posX,arenaTile.posY + 1].isEmpty)
        {
            transform.position = managerArena.tile[arenaTile.posX, arenaTile.posY + 1].transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.transform.tag == "Game_arenaTile")
        {
            arenaTile = obj.gameObject.GetComponent<arenaTileController>();
        }
    }

    public void setColor(blockColor col)
    {
        color = col;
        if (col == blockColor.GREEN) GetComponent<SpriteRenderer>().color = Color.green;
        else if (col == blockColor.RED) GetComponent<SpriteRenderer>().color = Color.red;
        else if (col == blockColor.BLUE) GetComponent<SpriteRenderer>().color = Color.blue;
        else if (col == blockColor.MAGENTA) GetComponent<SpriteRenderer>().color = Color.magenta;
        else if (col == blockColor.YELLOW) GetComponent<SpriteRenderer>().color = Color.yellow;
        else if (col == blockColor.ORANGE) GetComponent<SpriteRenderer>().color = new Color(1, 0.647f, 0);
        else if (col == blockColor.CYAN) GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
