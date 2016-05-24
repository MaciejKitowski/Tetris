using UnityEngine;
using System.Collections;

public class blockController_S : blockController
{
    override public void rotate()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 8) //DOWN -> RIGHT
        {
            actitveRotation = rotation.RIGHT;
            rotateTiles(1, 0, 1, 1, 2, 1);
        }
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posX > 0) //RIGHT -> UP
        {
            actitveRotation = rotation.UP;
            rotateTiles(0, -1, 1, -1, 1, -2);
        }
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 1) //UP -> LEFT
        {
            actitveRotation = rotation.LEFT;
            rotateTiles(-1, 0, -1, -1, -2, -1);
        }
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX > 0) //LEFT -> DOWN
        {
            actitveRotation = rotation.DOWN;
            rotateTiles(0, 1, -1, 1, -1, 2);
        }
    }

    override public void turnLeft()
    {
        if (actitveRotation == rotation.DOWN && tile[2].arenaTile.posX > 0) moveTilesHorizontal(-1);
        else if ((actitveRotation == rotation.RIGHT || actitveRotation == rotation.UP) && tile[0].arenaTile.posX > 0) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && tile[3].arenaTile.posX > 0) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 9) moveTilesHorizontal(1);
        else if ((actitveRotation == rotation.RIGHT || actitveRotation == rotation.UP) && tile[3].arenaTile.posX < 9) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posX < 9) moveTilesHorizontal(1);
    }
}
