using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputTap : MonoBehaviour {
    public float rotateTouchBorder = -3.3225f;
    public float moveDownTouchBorder = 0.95f;

    private bool activated = false;
    private EndGame endgame;
    private blocksManager blocks;
    private Settings settings;

    void Awake() {
        endgame = FindObjectOfType<EndGame>();
        blocks = FindObjectOfType<blocksManager>();
        settings = FindObjectOfType<Settings>();
    }

    void Update() {
        if(activated) {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                if(!GamePause.isPaused() && !settings.gameObject.activeInHierarchy && !endgame.isActive()) {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                    if (touchPos.y < rotateTouchBorder) blocks.getBlock().GetComponent<Block>().rotate();
                    else {
                        if (touchPos.x > -moveDownTouchBorder && touchPos.x < moveDownTouchBorder) blocks.getBlock().GetComponent<Block>().speedUp = true;
                        else if (touchPos.x < -moveDownTouchBorder) blocks.getBlock().GetComponent<Block>().turnLeft();
                        else if (touchPos.x > moveDownTouchBorder) blocks.getBlock().GetComponent<Block>().turnRight();
                    }
                }
                else if (GamePause.isPaused() && !settings.gameObject.activeInHierarchy && !endgame.gameObject.activeInHierarchy) GamePause.deactivate();
            }
        }
    }

    public void activate() { activated = true; }
    public void deactivate() { activated = false; }
}
