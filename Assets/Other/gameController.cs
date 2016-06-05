using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameController : MonoBehaviour
{
    public Text debug_touchPosition;

    private pointsCounter points;
    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private arenaManager managerArena;

    //Touch input (swipe)
    private Vector2 touchStartPos = new Vector2(0, 0);
    private Vector2 touchEndPos = new Vector2(0, 0);

    void Awake()
    {
        points = FindObjectOfType<pointsCounter>();
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<arenaManager>();
    }

    void Update()
    {
        //Touch input (tap)
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            debug_touchPosition.text = "X=" + touchPos.x + ", Y=" + touchPos.y;

            if (touchPos.y < -3.3225f) managerBlocks.getBlock().GetComponent<blockController>().rotate();
            else
            {
                if (touchPos.x > -0.95f && touchPos.x < 0.95f) managerBlocks.getBlock().GetComponent<blockController>().speedUp = true;
                else if (touchPos.x < -0.95f) managerBlocks.getBlock().GetComponent<blockController>().turnLeft();
                else if (touchPos.x > 0.95f) managerBlocks.getBlock().GetComponent<blockController>().turnRight();
            }
        }*/

        //Touch input (swipe)
        /*if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) touchStartPos = Input.GetTouch(0).position;
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchEndPos = Input.GetTouch(0).position;

                if(Mathf.Abs(touchEndPos.x - touchStartPos.x) > Mathf.Abs(touchEndPos.y - touchStartPos.y))
                {
                    if (touchEndPos.x > touchStartPos.x) managerBlocks.getBlock().GetComponent<blockController>().turnRight();
                    else managerBlocks.getBlock().GetComponent<blockController>().turnLeft();
                }
                else
                {
                    if (touchEndPos.y > touchStartPos.y) managerBlocks.getBlock().GetComponent<blockController>().rotate();
                    else managerBlocks.getBlock().GetComponent<blockController>().speedUp = true;
                }
            }
            debug_touchPosition.text = "X=" + touchStartPos.x + "/" + touchEndPos.x + ", Y=" + touchStartPos.y + "/" + touchEndPos.y;
        }*/
    }

	public void newGame()
    {
        points.resetPoints();
        managerBlocks.removeAllBlocks();
        managerArena.resetArena();
        nextBlock.randNew();
    }
}
