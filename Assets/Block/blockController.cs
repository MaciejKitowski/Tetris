using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
    public enum rotation { DOWN, RIGHT, UP, LEFT };
    public rotation actitveRotation = rotation.DOWN;
    public bool speedUp = false;
    public bool lockRotation = false;

    protected blockTileController[] tile = new blockTileController[4];
    protected arenaManager managerArena;
    protected blocksManager managerBlocks;
    protected detectorController detector;

    protected float fallTimer = 0.6f;
    protected float fallTimerFast = 0.02f;
    protected float timer = 0;

    virtual protected void Start() {
        for (int i = 0; i < 4; ++i) tile[i] = transform.GetChild(i).GetComponent<blockTileController>();
        managerArena = FindObjectOfType<arenaManager>();
        managerBlocks = FindObjectOfType<blocksManager>();
        detector = transform.GetComponentInChildren<detectorController>();
    }

    virtual protected void Update() {
        if(detector.canChangeDirectionVERT(actitveRotation)) {
            if (timer < 0) {
                moveTilesVertical();
                if (!speedUp) timer = fallTimer;
                else timer = fallTimerFast;
            }
            else timer -= Time.deltaTime;
        }
        else {
            managerBlocks.pushBlock();
            destroy();
        }
    }

    public void rotate() {
        if (detector.canRotate() && !lockRotation) {
            transform.Rotate(0, 0, 90f);
            int rot = (int)transform.eulerAngles.z / 90;
            actitveRotation = (rotation)rot;
        }
    }

    public void turnLeft() { if (detector.canChangeDirectionHOR(actitveRotation, -1)) moveTilesHorizontal(-1); }
    public void turnRight() { if (detector.canChangeDirectionHOR(actitveRotation, 1)) moveTilesHorizontal(1); }

    public void randColor() {
        blockTileController.blockColor col = (blockTileController.blockColor)Random.Range(0, 7);
        for (int i = 0; i < 4; ++i) transform.GetChild(i).GetComponent<blockTileController>().setColor(col);
    }

    protected void moveTilesHorizontal(int direction) { transform.position = managerArena.tile[tile[0].arenaTile.posX + direction, tile[0].arenaTile.posY].transform.position; }
    protected void moveTilesVertical(int direction = 1) { transform.position = managerArena.tile[tile[0].arenaTile.posX, tile[0].arenaTile.posY + direction].transform.position; }

    protected void destroy() {
        foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
        Destroy(detector.gameObject);
        Destroy(GetComponent<blockController>());
    }
}
