using UnityEngine;
using System.Collections;

public class blockController_I : blockController
{
    override public void rotate()
    {
        if (actitveRotation == rotation.DOWN && tile[0].arenaTile.posX < 7) //DOWN -> RIGHT
        {
            actitveRotation = rotation.RIGHT;
            rotateTiles(1, 0, 2, 0, 3, 0);
        }
        else if(actitveRotation == rotation.RIGHT && tile[0].arenaTile.posY > 2) //RIGHT -> UP
        {
            actitveRotation = rotation.UP;
            rotateTiles(0, -1, 0, -2, 0, -3);
        }
        else if (actitveRotation == rotation.UP && tile[0].arenaTile.posX > 2) //UP -> LEFT
        {
            actitveRotation = rotation.LEFT;
            rotateTiles(-1, 0, -2, 0, -3, 0);
        }
        else if (actitveRotation == rotation.LEFT && tile[0].arenaTile.posY < 17) //LEFT -> DOWN
        {
            actitveRotation = rotation.DOWN;
            rotateTiles(0, 1, 0, 2, 0, 3);
        }
    }

    override public void turnLeft()
    {
        if ((actitveRotation == rotation.DOWN || actitveRotation == rotation.RIGHT || actitveRotation == rotation.UP) && tile[0].arenaTile.posX > 0) moveTilesHorizontal(-1);
        else if (actitveRotation == rotation.LEFT && tile[3].arenaTile.posX > 0) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if ((actitveRotation == rotation.DOWN || actitveRotation == rotation.LEFT || actitveRotation == rotation.UP) && tile[0].arenaTile.posX < 9) moveTilesHorizontal(1);
        else if (actitveRotation == rotation.RIGHT && tile[3].arenaTile.posX < 9) moveTilesHorizontal(1);
    }
}
