using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {
    public GameObject[] inputButtons = new GameObject[4];

    private pointsCounter points;
    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private arenaManager managerArena;
    private GameObject pauseTxt;
    private GameObject controllerSettings;
    private EndGame endGame;

    //Touch input (swipe)
    private Vector2 touchStartPos = new Vector2(0, 0);
    private Vector2 touchEndPos = new Vector2(0, 0);

    void Awake() {
        points = FindObjectOfType<pointsCounter>();
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<arenaManager>();
        controllerSettings = GameObject.FindGameObjectWithTag("Settings");
        pauseTxt = GameObject.FindGameObjectWithTag("Game_pause");
        endGame = FindObjectOfType<EndGame>();
        gameObject.SetActive(false);
        controllerSettings.SetActive(false);
        endGame.gameObject.SetActive(false);
    }

    void Update() {
        //Input
        switch (Settings.selectedInput) {
            case Settings.InputMode.BUTTONS:
                selectedInputButtons();
                break;

            case Settings.InputMode.TOUCH_TAP:
                selectedInputTap();
                break;

            case Settings.InputMode.TOUCH_SWIPE:
                selectedInputSwipe();
                break;
        }       
    }

	public void newGame() {
        points.resetPoints();
        managerBlocks.removeAllBlocks();
        managerArena.resetArena();
        nextBlock.randNew();
        endGame.gameObject.SetActive(false);
    }

    public void buttonTurnLeft() {
        if (!GamePause.isPaused() && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<Block>().turnLeft();
        else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
    }

    public void buttonTurnRight() {
        if (!GamePause.isPaused() && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<Block>().turnRight();
        else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
    }

    public void buttonRotate() {
        if (!GamePause.isPaused() && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<Block>().rotate();
        else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
    }

    public void buttonSpeedUp() {
        if (!GamePause.isPaused() && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<Block>().speedUp = true;
        else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
    }

    public int getPoints() { return points.getPoints(); }

    private void selectedInputButtons() {
        if (!inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(true);
    }

    private void selectedInputTap() {
        if (inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(false);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (!GamePause.isPaused() && !controllerSettings.activeInHierarchy && !endGame.gameObject.activeInHierarchy)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (touchPos.y < -3.3225f) managerBlocks.getBlock().GetComponent<Block>().rotate();
                else {
                    if (touchPos.x > -0.95f && touchPos.x < 0.95f) managerBlocks.getBlock().GetComponent<Block>().speedUp = true;
                    else if (touchPos.x < -0.95f) managerBlocks.getBlock().GetComponent<Block>().turnLeft();
                    else if (touchPos.x > 0.95f) managerBlocks.getBlock().GetComponent<Block>().turnRight();
                }
            }
            else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
        }
    }

    private void selectedInputSwipe() {
        if (inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(false);

        if (Input.touchCount > 0) {
            if (!GamePause.isPaused() && !controllerSettings.activeInHierarchy && !endGame.gameObject.activeInHierarchy) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) touchStartPos = Input.GetTouch(0).position;
                else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                    touchEndPos = Input.GetTouch(0).position;

                    if (Mathf.Abs(touchEndPos.x - touchStartPos.x) > Mathf.Abs(touchEndPos.y - touchStartPos.y)) {
                        if (touchEndPos.x > touchStartPos.x) managerBlocks.getBlock().GetComponent<Block>().turnRight();
                        else managerBlocks.getBlock().GetComponent<Block>().turnLeft();
                    }
                    else {
                        if (touchEndPos.y > touchStartPos.y) managerBlocks.getBlock().GetComponent<Block>().rotate();
                        else managerBlocks.getBlock().GetComponent<Block>().speedUp = true;
                    }
                }
            }
            else if (GamePause.isPaused() && !controllerSettings.activeInHierarchy) GamePause.deactivate();
        }
    }
}
