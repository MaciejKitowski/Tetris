using UnityEngine;
using System.Collections;

public class blockController_L : blockController
{
    override public void rotate()
    {
        if(actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 8) //DOWN -> RIGHT
        {
            actitveRotation = rotation.RIGHT;
            rotateTiles(0, 1, 1, 1, 2, 1);
        }
        else if (actitveRotation == rotation.RIGHT && tile[0].arenaTile.posY > 1) //RIGHT -> UP
        {
            actitveRotation = rotation.UP;
            rotateTiles(1, 0, 1, -1, 1, -2);
        }
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 1) //UP -> LEFT
        {
            actitveRotation = rotation.LEFT;
            rotateTiles(0, -1, -1, -1, -2, -1);
        }
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posY < 19) //LEFT -> DOWN
        {
            actitveRotation = rotation.DOWN;
            rotateTiles(-1, 0, -1, 1, -1, 2);
        }
    }

    override public void turnLeft()
    {
        if ((actitveRotation == rotation.DOWN || actitveRotation == rotation.RIGHT) && tile[1].arenaTile.posX > 0) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 0) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && tile[3].arenaTile.posX > 0) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 9) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.RIGHT && tile[3].arenaTile.posX < 9) moveTilesHorizontal(1);
        else if ((actitveRotation == rotation.UP || actitveRotation == rotation.LEFT) && tile[1].arenaTile.posX < 9) moveTilesHorizontal(1);
    }
}
