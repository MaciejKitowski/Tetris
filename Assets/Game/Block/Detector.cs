using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
    private DetectorTile[] down, up, right, left, rotation;

	void Start () {
        load(ref down, 0);
        load(ref up, 1);
        load(ref left, 2);
        load(ref right, 3);
        load(ref rotation, 4);
    }

    public bool canMoveVertical(Block.rotation rot, int direction = 1) {
        switch(rot) {
            case Block.rotation.DOWN:
                if (direction == 1) return checkDetectorArray(down, true);
                else return checkDetectorArray(up, true);

            case Block.rotation.RIGHT:
                if (direction == 1) return checkDetectorArray(left, true);
                else return checkDetectorArray(right, true);

            case Block.rotation.UP:
                if (direction == 1) return checkDetectorArray(up, true);
                else return checkDetectorArray(down, true);

            case Block.rotation.LEFT:
                if (direction == 1) return checkDetectorArray(right, true);
                else return checkDetectorArray(left, true);
        }
        return false;
    }

    public bool canMoveHorizontal(Block.rotation rot, int direction) {
        switch (rot) {
            case Block.rotation.DOWN:
                if(direction == -1) return checkDetectorArray(left);
                else return checkDetectorArray(right);

            case Block.rotation.RIGHT:
                if (direction == -1) return checkDetectorArray(up);
                else return checkDetectorArray(down);

            case Block.rotation.UP:
                if (direction == -1) return checkDetectorArray(right);
                else return checkDetectorArray(left);

            case Block.rotation.LEFT:
                if (direction == -1) return checkDetectorArray(down);
                else return checkDetectorArray(up);
        }
        return false;
    }

    public bool canRotate() { return checkDetectorArray(rotation); }

    private void load(ref DetectorTile[] det, int childIndex) {
        det = new DetectorTile[transform.GetChild(childIndex).childCount];
        for (int i = 0; i < transform.GetChild(childIndex).childCount; ++i) det[i] = transform.GetChild(childIndex).transform.GetChild(i).GetComponent<DetectorTile>();
    }

    private bool checkDetectorArray(DetectorTile[] ar, bool vertical = false) {
        foreach (DetectorTile tl in ar) {
            if (tl.detectedObj == null) return false;
            else if (tl.detectedObj.tag == "Game_arenaTile" && !tl.detectedObj.GetComponent<ArenaTile>().isEmpty) return false;
            else if (tl.detectedObj.tag == "Game_blockTile") return false;
            else if (tl.detectedObj.tag == "Game_border" && !vertical) return false;
            else if (tl.detectedObj.tag == "Game_border" && vertical && tl.detectedObj.name == "Down") return false;
        }
        return true;
    }
}
