using UnityEngine;
using System.Collections;

public class detectorTile : MonoBehaviour
{
    public GameObject detectedObj;
    
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag != "Game_detector") detectedObj = obj.gameObject;
        //if (detectedObj != null && detectedObj.tag == "Game_border") detectedObj = null;
    }
}
