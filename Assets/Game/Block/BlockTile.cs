using UnityEngine;

public class BlockTile : MonoBehaviour {
    public enum blockColor { GREEN, RED, BLUE, MAGENTA, YELLOW, ORANGE, CYAN };

    public bool blockControllerRemoved = false;
    public ArenaTile arenaTile;
    public blockColor color = blockColor.GREEN;

    private Arena managerArena;

    void Start() { managerArena = GameObject.FindGameObjectWithTag("Game_arena").GetComponent<Arena>(); }

    void Update() {
        if(blockControllerRemoved && arenaTile.posY < 19 && managerArena.tile[arenaTile.posX,arenaTile.posY + 1].isEmpty) {
            transform.position = managerArena.tile[arenaTile.posX, arenaTile.posY + 1].transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D obj) {
        if (obj.transform.tag == "Game_arenaTile") arenaTile = obj.gameObject.GetComponent<ArenaTile>();
    }

    public void setColor(blockColor col) {
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
