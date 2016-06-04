using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{
    private pointsCounter points;
    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private arenaManager managerArena;

    void Awake()
    {
        points = FindObjectOfType<pointsCounter>();
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<arenaManager>();
    }

	public void newGame()
    {
        points.resetPoints();
        managerBlocks.removeAllBlocks();
        managerArena.resetArena();
        nextBlock.randNew();
    }
}
