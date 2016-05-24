using UnityEngine;
using System.Collections;

public class blockControllerI : MonoBehaviour
{
    private blockTileController[] tile = new blockTileController[4];
    private arenaManager managerArena;
   
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 4; ++i) tile[i] = transform.GetChild(i).GetComponent<blockTileController>();
        managerArena = FindObjectOfType<arenaManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R)) rotate();
	}

    public void rotate()
    {
        //Down - set to right
        if (tile[0].arenaTile.posY < tile[1].arenaTile.posY && tile[0].arenaTile.posX < 7)
        {
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX + 1, tile[0].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX + 2, tile[0].arenaTile.posY].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX + 3, tile[0].arenaTile.posY].transform.position;
        }

        //Right - set to up
        if (tile[0].arenaTile.posX < tile[1].arenaTile.posX && tile[0].arenaTile.posY > 2)
        {
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY - 1].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY - 2].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY - 3].transform.position;
        }

        //Up - set to left
        if (tile[0].arenaTile.posY > tile[1].arenaTile.posY && tile[0].arenaTile.posX > 2)
        {
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX - 1, tile[0].arenaTile.posY].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX - 2, tile[0].arenaTile.posY].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX - 3, tile[0].arenaTile.posY].transform.position;
        }

        //Left - set to down
        if (tile[0].arenaTile.posX > tile[1].arenaTile.posX && tile[0].arenaTile.posY < 17)
        {
            tile[1].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + 1].transform.position;
            tile[2].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + 2].transform.position;
            tile[3].transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + 3].transform.position;
        }
    }
}
