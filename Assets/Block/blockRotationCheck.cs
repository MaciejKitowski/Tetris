using UnityEngine;
using System.Collections;

public class blockRotationCheck : MonoBehaviour
{
    public arenaTileController activeBlock;

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.transform.tag == "Game_arenaTile") activeBlock = obj.gameObject.GetComponent<arenaTileController>();
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        activeBlock = null;
    }
}
