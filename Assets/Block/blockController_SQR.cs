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
}
