using UnityEngine;
using System.Collections;

public class blockControllerSQR : MonoBehaviour
{
    private blockTileController[] tile = new blockTileController[4];
    private arenaManager managerArena;
    private enum rotation { DOWN, RIGHT, UP, LEFT };
    private rotation actitveRotation = rotation.DOWN;

    void Start()
    {
        for (int i = 0; i < 4; ++i) tile[i] = transform.GetChild(i).GetComponent<blockTileController>();
        managerArena = FindObjectOfType<arenaManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) rotate();
        else if (Input.GetKeyDown(KeyCode.A)) turnLeft();
        else if (Input.GetKeyDown(KeyCode.D)) turnRight();
    }

    public void rotate()
    {

    }

    public void turnLeft()
    {
        if (tile[0].arenaTile.posX > 0)
        {
            tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
            tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX - 1, tile[1].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX - 1, tile[2].arenaTile.posY].transform.position;
            tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX - 1, tile[3].arenaTile.posY].transform.position;
        }
    }

    public void turnRight()
    {
        if (tile[1].arenaTile.posX < 9)
        {
            tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
            tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX + 1, tile[1].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX + 1, tile[2].arenaTile.posY].transform.position;
            tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX + 1, tile[3].arenaTile.posY].transform.position;
        }
    }
}
