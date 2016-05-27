using UnityEngine;
using System.Collections;

public class blockController_SQR : blockController
{
    override public void turnLeft()
    {
        if (canTurn(new int[2] { 0, 2 }, -1)) moveTilesHorizontal(-1);
    }

    override public void turnRight()
    {
        if (canTurn(new int[2] { 1, 3 }, 1)) moveTilesHorizontal(1);
    }

    override public void fallDown()
    {
        if (actitveRotation == rotation.DOWN && canFallDown(new int[2] { 2, 3 }, 2)) moveTilesVertical(1);
        else if (actitveRotation == rotation.RIGHT) { }
        else if (actitveRotation == rotation.UP) { }
        else if (actitveRotation == rotation.LEFT) { }
        //else canFall = false;
        else
        {
            canFall = false;
            foreach (blockTileController tl in tile) tl.blockControllerRemoved = true;
            managerBlocks.pushBlock();
            Destroy(GetComponent<blockController>());
        }
    }
}
