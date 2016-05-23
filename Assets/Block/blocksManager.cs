using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour
{
    public GameObject[] blockPrefab;
    public GameObject startPosition;

    private nextBlockController nextBlock;

    void Awake()
    {
        if (Debug.isDebugBuild) checkErrors();
        nextBlock = FindObjectOfType<nextBlockController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) addNewBlock();
    }

    public void addNewBlock()
    {
        GameObject buffer = Instantiate(nextBlock.getBlock());
        buffer.transform.SetParent(transform);
        buffer.transform.localScale = new Vector3(1, 1);
        buffer.transform.localPosition = new Vector3(startPosition.transform.localPosition.x + 0.32f, startPosition.transform.localPosition.y - 0.36f);

        nextBlock.randBlock();
    }

    private void checkErrors()
    {
        if (startPosition == null) Debug.LogError("blocksManager - startPosition is empty");
        if (blockPrefab.Length == 0) Debug.LogError("blocksManager - blockPrefab array have 0 prefabs");
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
