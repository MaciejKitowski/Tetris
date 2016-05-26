using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour
{
    public GameObject startTile;
    private nextBlockController nextBlock;

	void Awake()
    {
        nextBlock = FindObjectOfType<nextBlockController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space)) pushBlock();
	}

    public void pushBlock()
    {
        GameObject buffer = Instantiate(nextBlock.getBlock()) as GameObject;
        buffer.transform.SetParent(transform);
        buffer.transform.SetAsLastSibling();
        buffer.transform.localPosition = startTile.transform.localPosition;

        buffer.GetComponent<blockController>().canFall = true;
        nextBlock.randNew();
    }
}
