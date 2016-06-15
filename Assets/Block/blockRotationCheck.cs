using UnityEngine;
using System.Collections;

public class blockRotationCheck : MonoBehaviour
{
    public arenaTileController activeBlock;

    /*void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "Game_arenaTile") activeBlock = obj.gameObject.GetComponent<arenaTileController>();
        else if (obj.transform.tag == "Game_blockTile") activeBlock = obj.gameObject.GetComponent<blockTileController>().arenaTile;
    }*/

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.transform.tag == "Game_arenaTile") activeBlock = obj.gameObject.GetComponent<arenaTileController>();
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        activeBlock = null;
    }
}
