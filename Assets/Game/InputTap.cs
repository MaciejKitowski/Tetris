using UnityEngine;

public class InputTap : MonoBehaviour {
    public float rotateTouchBorder = -3.3225f;
    public float moveDownTouchBorder = 0.95f;

    private bool activated = false;
    private EndGame endgame;
    private blocksManager blocks;
    private Settings settings;
    private Vector2 touchPos;

    /*void Awake() {
        endgame = FindObjectOfType<EndGame>();
        blocks = FindObjectOfType<blocksManager>();
        settings = FindObjectOfType<Settings>();
    }*/

    public void initiate(EndGame end, blocksManager block, Settings sett)
    {
        endgame = end;
        blocks = block;
        settings = sett;
    }

    void Update() {
        if(activated && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (!GamePause.isPaused() && isExtraWindowsDisabled()) {
                touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (toRotate()) blocks.getBlock().GetComponent<Block>().rotate();
                else if (toMoveDown()) blocks.getBlock().GetComponent<Block>().speedUp = true;
                else if (toTurnLeft()) blocks.getBlock().GetComponent<Block>().turnLeft();
                else blocks.getBlock().GetComponent<Block>().turnRight();
            }
            else GamePause.deactivateAnimated();
        }
    }

    public void activate() { activated = true; }
    public void deactivate() { activated = false; }

    private bool toRotate() { return (touchPos.y < rotateTouchBorder); }
    private bool toTurnLeft() { return (touchPos.x < -moveDownTouchBorder); }
    private bool toMoveDown() { return (touchPos.x > -moveDownTouchBorder && touchPos.x < moveDownTouchBorder); }

    private bool isExtraWindowsDisabled() {
        if (!settings.isActive() && !endgame.isActive()) return true;
        else return false;
    }
}
