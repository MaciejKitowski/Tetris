using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour
{
    public enum rotation { DOWN, RIGHT, UP, LEFT };
    public rotation actitveRotation = rotation.DOWN;
    public bool canFall = false;

    protected blockTileController[] tile = new blockTileController[4];
    protected arenaManager managerArena;

    protected float fallTimer = 1f;
    protected float timer = 0;

    virtual public void Start()
    {
        for (int i = 0; i < 4; ++i) tile[i] = transform.GetChild(i).GetComponent<blockTileController>();
        managerArena = FindObjectOfType<arenaManager>();
    }

    virtual public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) rotate();
        else if (Input.GetKeyDown(KeyCode.A)) turnLeft();
        else if (Input.GetKeyDown(KeyCode.D)) turnRight();
        else if (Input.GetKeyDown(KeyCode.W)) canFall = true;

        if(canFall)
        {
            if (timer < 0)
            {
                fallDown();
                timer = fallTimer;
            }
            else timer -= Time.deltaTime;
        }
    }

    virtual public void rotate() { }
    virtual public void turnLeft() { }
    virtual public void turnRight() { }
    virtual public void fallDown() { }

    protected void moveTilesHorizontal(int direction)
    {
        tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX + direction, tile[0].arenaTile.posY].transform.position;
        tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX + direction, tile[1].arenaTile.posY].transform.position;
        tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX + direction, tile[2].arenaTile.posY].transform.position;
        tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX + direction, tile[3].arenaTile.posY].transform.position;
    }

    protected void moveTilesVertical(int direction)
    {
        tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + direction].transform.position;
        tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX, tile[1].arenaTile.posY + direction].transform.position;
        tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX, tile[2].arenaTile.posY + direction].transform.position;
        tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX, tile[3].arenaTile.posY + direction].transform.position;
    }

    protected void rotateTiles(int firstTileX, int firstTileY, int secondTileX, int secondTileY, int thirdTileX, int thirdTileY)
    {
        tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX + firstTileX, tile[0].arenaTile.posY + firstTileY].transform.position;
        tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX + secondTileX, tile[0].arenaTile.posY + secondTileY].transform.position;
        tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX + thirdTileX, tile[0].arenaTile.posY + thirdTileY].transform.position;
    }
}
