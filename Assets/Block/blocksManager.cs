using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject[] blockPrefab;

    void Awake()
    {
        if (Debug.isDebugBuild) checkErrors();
    }

    private void checkErrors()
    {
        if (startPosition == null) Debug.LogError("blocksManager - startPosition is empty");
        if(blockPrefab.Length == 0) Debug.LogError("blocksManager - blockPrefab array have 0 prefabs");
        foreach (GameObject obj in blockPrefab)
        {
            if (obj == null)
            {
                Debug.LogError("blocksManager - blockPrefab is empty");
                break;
            }
        }   
    }
}
