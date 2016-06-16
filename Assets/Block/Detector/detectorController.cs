using UnityEngine;
using System.Collections;

public class detectorController : MonoBehaviour
{
    private detectorTile[] down, up, right, left, rotation;

	void Start ()
    {
        load(ref down, 0);
        load(ref up, 1);
        load(ref left, 2);
        load(ref right, 3);
        load(ref rotation, 4);
    }

    public bool canChangeDirectionVERT(blockController.rotation rot, int direction = 1)
    {
        switch(rot)
        {
            case blockController.rotation.DOWN:
                if(direction == 1) return checkDetectorArray(down);
                else return checkDetectorArray(up);

            case blockController.rotation.RIGHT:
                if (direction == 1) return checkDetectorArray(left);
                else return checkDetectorArray(right);

            case blockController.rotation.UP:
                if (direction == 1) return checkDetectorArray(up);
                else return checkDetectorArray(down);

            case blockController.rotation.LEFT:
                if (direction == 1) return checkDetectorArray(right);
                else return checkDetectorArray(left);
        }
        return false;
    }

    public bool canChangeDirectionHOR(blockController.rotation rot, int direction)
    {
        switch (rot)
        {
            case blockController.rotation.DOWN:
                if(direction == -1) return checkDetectorArray(left);
                else return checkDetectorArray(right);

            case blockController.rotation.RIGHT:
                if (direction == -1) return checkDetectorArray(up);
                else return checkDetectorArray(down);

            case blockController.rotation.UP:
                if (direction == -1) return checkDetectorArray(right);
                else return checkDetectorArray(left);

            case blockController.rotation.LEFT:
                if (direction == -1) return checkDetectorArray(down);
                else return checkDetectorArray(up);
        }
        return false;
    }

    public bool canRotate() { return checkDetectorArray(rotation); }

    private void load(ref detectorTile[] det, int childIndex)
    {
        det = new detectorTile[transform.GetChild(childIndex).childCount];
        for (int i = 0; i < transform.GetChild(childIndex).childCount; ++i) det[i] = transform.GetChild(childIndex).transform.GetChild(i).GetComponent<detectorTile>();
    }

    private bool checkDetectorArray(detectorTile[] ar)
    {
        foreach (detectorTile tl in ar)
        {
            if (tl.detectedObj == null) return false;
            else if (tl.detectedObj.tag == "Game_arenaTile" && !tl.detectedObj.GetComponent<arenaTileController>().isEmpty) return false;
            else if (tl.detectedObj.tag == "Game_blockTile") return false;
        }
        return true;
    }
}
