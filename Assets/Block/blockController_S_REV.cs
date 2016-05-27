using UnityEngine;
using System.Collections;

public class blockController_S_REV : blockController
{
    override public void rotate()
    {
        if(actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 8) //DOWN -> RIGHT
        {
            actitveRotation = rotation.RIGHT;
            rotateTiles(1, 0, 1, -1, 2, -1);
        }
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posX > 0 && tile[0].arenaTile.posY > 1) //RIGHT -> UP
        {
            actitveRotation = rotation.UP;
            rotateTiles(0, -1, -1, -1, -1, -2);
        }
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 1) //UP -> LEFT
        {
            actitveRotation = rotation.LEFT;
            rotateTiles(-1, 0, -1, 1, -2, 1);
        }
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX < 9 && tile[0].arenaTile.posY < 18) //LEFT -> DOWN
        {
            actitveRotation = rotation.DOWN;
            rotateTiles(0, 1, 1, 1, 1, 2);
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

    override public void fallDown()
    {
        if (actitveRotation == rotation.DOWN && canFallDown(new int[2] { 1, 3 }, 3)) moveTilesVertical(1);
        else if (actitveRotation == rotation.RIGHT && canFallDown(new int[3] { 0, 1, 3 }, 0)) moveTilesVertical(1);
        else if (actitveRotation == rotation.UP && canFallDown(new int[2] { 0, 2 }, 0)) moveTilesVertical(1);
        else if (actitveRotation == rotation.LEFT && canFallDown(new int[2] { 2, 3 }, 2)) moveTilesVertical(1);
        //else canFall = false;
        else
        {
            canFall = false;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }
}
