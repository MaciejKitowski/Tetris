using UnityEngine;
using System.Collections;

public class nextBlockController : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    void Awake()
    {
        if (transform.childCount == 0) randNew();
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F)) randNew();
	}

    public void randNew()
    {
        if(transform.childCount > 0) foreach (Transform obj in transform) Destroy(obj.gameObject);
        int randIndex = Random.Range(0, 7);

        GameObject buffer = Instantiate(blockPrefabs[randIndex]) as GameObject;
        buffer.transform.SetParent(transform);
        buffer.transform.localPosition = new Vector2(0, 0);
        
        buffer.GetComponent<blockController>().randColor();
    }

    public GameObject getBlock()
    {
        return transform.GetChild(0).gameObject;
    }
}
