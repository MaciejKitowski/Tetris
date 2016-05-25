using UnityEngine;
using System.Collections;

public class blockController_SQR : blockController
{
    override public void turnLeft()
    {
        if (tile[0].arenaTile.posX > 0) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (tile[1].arenaTile.posX < 9) moveTilesHorizontal(1);
    }

    override public void fallDown()
    {
        if (actitveRotation == rotation.DOWN && tile[3].arenaTile.posY < 19 && managerArena.tile[tile[2].arenaTile.posX, tile[2].arenaTile.posY + 1].isEmpty
             && managerArena.tile[tile[3].arenaTile.posX, tile[3].arenaTile.posY + 1].isEmpty) moveTilesVertical(1);

        else if (actitveRotation == rotation.RIGHT) { }
        else if (actitveRotation == rotation.UP) { }
        else if (actitveRotation == rotation.LEFT) { }
        else canFall = false;
    }
}
