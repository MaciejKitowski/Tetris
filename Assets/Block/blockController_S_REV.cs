using UnityEngine;
using System.Collections;

public class blockController_S_REV : blockController
{
    override public void rotate()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX >= 8) moveTilesHorizontal(-(tile[0].arenaTile.posX - 7));
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posY <= 1) moveTilesVertical(2 - tile[0].arenaTile.posY);
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posX == 0) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX <= 1) moveTilesHorizontal(2 - tile[0].arenaTile.posX);
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posY >= 18) moveTilesVertical(-(tile[0].arenaTile.posY - 17));
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX == 9) moveTilesHorizontal(-1);

        if (canRotate())
        {
            transform.Rotate(0, 0, 90f);
            int rot = (int)transform.eulerAngles.z / 90;
            actitveRotation = (rotation)rot;
        }
    }

    override public void turnLeft()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[2] { 0, 1 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[1] { 0 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.UP && canTurn(new int[2] { 2, 3 }, -1)) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[1] { 3 }, -1)) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (actitveRotation == rotation.DOWN && canTurn(new int[2] { 2, 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.RIGHT && canTurn(new int[1] { 3 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.UP && canTurn(new int[2] { 0, 1 }, 1)) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.LEFT && canTurn(new int[1] { 0 }, 1)) moveTilesHorizontal(1);
    }

    override protected void fallDown()
    {
        if (actitveRotation == rotation.DOWN && canFallDown(new int[2] { 1, 3 }, 3)) moveTilesVertical();
        else if (actitveRotation == rotation.RIGHT && canFallDown(new int[3] { 0, 1, 3 }, 0)) moveTilesVertical();
        else if (actitveRotation == rotation.UP && canFallDown(new int[2] { 0, 2 }, 0)) moveTilesVertical();
        else if (actitveRotation == rotation.LEFT && canFallDown(new int[2] { 2, 3 }, 2)) moveTilesVertical();
        else
        {
            canFall = false;
            foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }
}
