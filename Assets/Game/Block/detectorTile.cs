using UnityEngine;
using System.Collections;

public class DetectorTile : MonoBehaviour {
    public GameObject detectedObj;
    
    void OnCollisionEnter2D(Collision2D obj) { if (obj.transform.tag != "Game_detector") detectedObj = obj.gameObject; }
}
