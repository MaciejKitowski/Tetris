using UnityEngine;
using System.Collections;

public class nextBlockController : MonoBehaviour
{
    public float scaleBig = 0.7f;
    public float scaleSmall = 0.4f;
    public float positionDifference = 0.8f;

    private blocksManager blockManager;

    void Awake()
    {
        blockManager = FindObjectOfType<blocksManager>();
        randBlocksAll();
    }

	void Update ()
    {
	    if(Debug.isDebugBuild)
        {
            if (Input.GetKeyDown(KeyCode.R)) randBlocksAll();
            if (Input.GetKeyDown(KeyCode.E)) randBlock();
        }
	}

    public void randBlock()
    {
        Destroy(transform.GetChild(0).gameObject); //Remove old block

        //Set small block as big
        GameObject buffer = transform.GetChild(1).gameObject;
        buffer.transform.localScale = new Vector3(scaleBig, scaleBig);
        buffer.transform.localPosition = new Vector3(0, 0);
        buffer.transform.SetSiblingIndex(0);

        //Rand new block
        buffer = Instantiate(blockManager.blockPrefab[Random.Range(0, blockManager.blockPrefab.Length)]) as GameObject;
        buffer.transform.SetParent(gameObject.transform);
        buffer.transform.localScale = new Vector3(scaleSmall, scaleSmall);
        buffer.transform.localPosition = new Vector3(0, positionDifference);
        buffer.transform.SetSiblingIndex(1);
    }

    public void randBlocksAll()
    {
        foreach (Transform obj in transform) Destroy(obj.gameObject); //Remove old blocks

        //First block
        GameObject buffer = Instantiate(blockManager.blockPrefab[Random.Range(0, blockManager.blockPrefab.Length)]) as GameObject;
        buffer.transform.SetParent(gameObject.transform);
        buffer.transform.localScale = new Vector3(scaleBig, scaleBig);
        buffer.transform.localPosition = new Vector3(0, 0);
        buffer.transform.SetSiblingIndex(0);

        //Second block
        buffer = Instantiate(blockManager.blockPrefab[Random.Range(0, blockManager.blockPrefab.Length)]) as GameObject;
        buffer.transform.SetParent(gameObject.transform);
        buffer.transform.localScale = new Vector3(scaleSmall, scaleSmall);
        buffer.transform.localPosition = new Vector3(0, positionDifference);
        buffer.transform.SetSiblingIndex(1);
    }
}
