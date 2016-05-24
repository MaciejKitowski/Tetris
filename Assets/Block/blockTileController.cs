using UnityEngine;
using System.Collections;

public class blockTileController : MonoBehaviour
{
    public arenaTileController arenaTile;

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.transform.tag == "Game_arenaTile")
        {
            arenaTile = obj.gameObject.GetComponent<arenaTileController>();
        }
    }
}
