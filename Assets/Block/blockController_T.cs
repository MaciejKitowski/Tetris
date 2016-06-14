using UnityEngine;
using System.Collections;

public class blockController_T : blockController
{
    override public void rotate()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX == 9) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posY == 0) moveTilesVertical(1);
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posX == 0) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX == 0) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX == 9) moveTilesHorizontal(-1);

        transform.Rotate(0, 0, 90f);
        int rot = (int)transform.eulerAngles.z / 90;
        actitveRotation = (rotation)rot;
    }

    override public void turnLeft()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[1] { 2 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[1] { 0 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.UP && canTurn(new int[1] { 3 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[3] { 1, 2, 3 }, -1)) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[1] { 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[3] { 1, 2, 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.UP && canTurn(new int[1] { 2 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[1] { 0 }, 1)) moveTilesHorizontal(1);
    }

    override protected void fallDown()
    {
        if (actitveRotation == rotation.DOWN && canFallDown(new int[3] { 1, 2, 3 }, 1)) moveTilesVertical();
        else if (actitveRotation == rotation.RIGHT && canFallDown(new int[2] { 0, 2 }, 2)) moveTilesVertical();
        else if (actitveRotation == rotation.UP && canFallDown(new int[3] { 0, 2, 3 }, 0)) moveTilesVertical();
        else if (actitveRotation == rotation.LEFT && canFallDown(new int[2] { 0, 3 }, 3)) moveTilesVertical();
        else
        {
            canFall = false;
            foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }
}
