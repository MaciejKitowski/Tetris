using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour
{
    public enum rotation { DOWN, RIGHT, UP, LEFT };
    public rotation actitveRotation = rotation.DOWN;
    public bool canFall = false;
    public bool speedUp = false;

    protected blockTileController[] tile = new blockTileController[4];
    protected blockRotationCheck[] rotationTile;
    protected arenaManager managerArena;
    protected blocksManager managerBlocks;
    protected detectorController detector;

    protected float fallTimer = 0.6f;
    protected float fallTimerFast = 0.02f;
    protected float timer = 0;

    virtual protected void Start()
    {
        rotationTile = new blockRotationCheck[transform.GetChild(4).childCount];

        for (int i = 0; i < 4; ++i) tile[i] = transform.GetChild(i).GetComponent<blockTileController>();
        for (int i = 0; i < transform.GetChild(4).childCount; ++i) rotationTile[i] = transform.GetChild(4).GetChild(i).GetComponent<blockRotationCheck>();
        managerArena = FindObjectOfType<arenaManager>();
        managerBlocks = FindObjectOfType<blocksManager>();
        detector = transform.GetComponentInChildren<detectorController>();
    }

    virtual protected void Update()
    {
        canFall = detector.canChangeDirectionVERT(actitveRotation);

        //if (canFall)
        if(detector.canChangeDirectionVERT(actitveRotation))
        {
            if (timer < 0)
            {
                moveTilesVertical();
                if (!speedUp) timer = fallTimer;
                else timer = fallTimerFast;
            }
            else timer -= Time.deltaTime;
        }
        else
        {
            foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }

    virtual public void rotate()
    {
        if (detector.canRotate())
        {
            transform.Rotate(0, 0, 90f);
            int rot = (int)transform.eulerAngles.z / 90;
            actitveRotation = (rotation)rot;
        }
    }

    virtual public void turnLeft()
    {
        if (detector.canChangeDirectionHOR(actitveRotation, -1)) moveTilesHorizontal(-1);
    }

    virtual public void turnRight()
    {
        if (detector.canChangeDirectionHOR(actitveRotation, 1)) moveTilesHorizontal(1);
    }


    virtual protected void fallDown() { }

    virtual public void randColor()
    {
        blockTileController.blockColor col = (blockTileController.blockColor)Random.Range(0, 7);
        for (int i = 0; i < 4; ++i) transform.GetChild(i).GetComponent<blockTileController>().setColor(col);
    }

    protected void moveTilesHorizontal(int direction)
    {
        transform.position = managerArena.tile[tile[0].arenaTile.posX + direction, tile[0].arenaTile.posY].transform.position;
    }

    protected void moveTilesVertical(int direction = 1)
    {
        transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + direction].transform.position;
    }

    protected bool canTurn(int[] tileIndex, int direction)
    {
        foreach(int i in tileIndex)
        {
            if (tile[i].arenaTile.posX + direction > 9 || tile[i].arenaTile.posX + direction < 0 || !managerArena.tile[tile[i].arenaTile.posX + direction, tile[i].arenaTile.posY].isEmpty) return false;
        }
        return true;
    }

    protected bool canFallDown(int[] tileIndex, int tileDown)
    {
        if (tile[tileDown].arenaTile.posY < 19)
        {
            foreach(int i in tileIndex)
            {
                if (!managerArena.tile[tile[i].arenaTile.posX, tile[i].arenaTile.posY + 1].isEmpty) return false;
            }
        }
        else return false;
        return true;
    }

    protected bool canRotate()
    {
        foreach(blockRotationCheck tl in rotationTile)
        {
            if (tl.activeBlock == null || !tl.activeBlock.isEmpty) return false;
        }

        return true;
    }
}
