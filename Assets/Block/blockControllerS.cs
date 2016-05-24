using UnityEngine;
using System.Collections;

public class blockControllerS : MonoBehaviour
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
        //Down - set to right
        if (tile[0].arenaTile.posY < tile[1].arenaTile.posY && tile[0].arenaTile.posX < 8)
        {
            actitveRotation = rotation.RIGHT;
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY + 1].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX + 2, tile[0].arenaTile.posY + 1].transform.position;
        }

        //Right - set to up
        if (tile[0].arenaTile.posX < tile[1].arenaTile.posX && tile[0].arenaTile.posX > 0)
        {
            actitveRotation = rotation.UP;
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY - 1].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY - 1].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY - 2].transform.position;
        }

        //Up - set to left
        if (tile[0].arenaTile.posY > tile[1].arenaTile.posY && tile[0].arenaTile.posX > 1)
        {
            actitveRotation = rotation.LEFT;
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY - 1].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX - 2, tile[0].arenaTile.posY - 1].transform.position;
        }

        //Left - set to down
        if (tile[0].arenaTile.posX > tile[1].arenaTile.posX && tile[0].arenaTile.posX > 0)
        {
            actitveRotation = rotation.DOWN;
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + 1].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY + 1].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY + 2].transform.position;
        }
    }

    public void turnLeft()
    {
        if (actitveRotation == rotation.DOWN)
        {
            if (tile[2].arenaTile.posX > 0)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX - 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX - 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX - 1, tile[3].arenaTile.posY].transform.position;
            }
        }
        else if (actitveRotation == rotation.RIGHT || actitveRotation == rotation.UP)
        {
            if (tile[0].arenaTile.posX > 0)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX - 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX - 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX - 1, tile[3].arenaTile.posY].transform.position;
            }
        }
        else if (actitveRotation == rotation.LEFT)
        {
            if (tile[3].arenaTile.posX > 0)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX - 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX - 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX - 1, tile[3].arenaTile.posY].transform.position;
            }
        }
    }

    public void turnRight()
    {
        if (actitveRotation == rotation.DOWN)
        {
            if (tile[0].arenaTile.posX < 9)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX + 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX + 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX + 1, tile[3].arenaTile.posY].transform.position;
            }
        }
        else if (actitveRotation == rotation.RIGHT || actitveRotation == rotation.UP)
        {
            if (tile[3].arenaTile.posX < 9)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX + 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX + 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX + 1, tile[3].arenaTile.posY].transform.position;
            }
        }
        else if (actitveRotation == rotation.LEFT)
        {
            if (tile[0].arenaTile.posX < 9)
            {
                tile[0].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
                tile[1].transform.position = managerArena.tile[tile[1].arenaTile.posX + 1, tile[1].arenaTile.posY].transform.position;
                tile[2].transform.position = managerArena.tile[tile[2].arenaTile.posX + 1, tile[2].arenaTile.posY].transform.position;
                tile[3].transform.position = managerArena.tile[tile[3].arenaTile.posX + 1, tile[3].arenaTile.posY].transform.position;
            }
        }
    }
}
