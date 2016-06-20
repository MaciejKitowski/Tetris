using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameController : MonoBehaviour {
    public GameObject[] inputButtons = new GameObject[4];
    public bool paused = true;

    private pointsCounter points;
    private blocksManager managerBlocks;
    private nextBlockController nextBlock;
    private arenaManager managerArena;
    private Settings settings;
    private GameObject pauseTxt;
    private GameObject controllerSettings;
    private endGameController endGame;

    //Touch input (swipe)
    private Vector2 touchStartPos = new Vector2(0, 0);
    private Vector2 touchEndPos = new Vector2(0, 0);

    void Awake() {
        points = FindObjectOfType<pointsCounter>();
        managerBlocks = FindObjectOfType<blocksManager>();
        nextBlock = FindObjectOfType<nextBlockController>();
        managerArena = FindObjectOfType<arenaManager>();
        settings = FindObjectOfType<Settings>();
        controllerSettings = GameObject.FindGameObjectWithTag("Settings");
        pauseTxt = GameObject.FindGameObjectWithTag("Game_pause");
        endGame = FindObjectOfType<endGameController>();
        gameObject.SetActive(false);
        controllerSettings.SetActive(false);
        endGame.gameObject.SetActive(false);
    }

    void Update() {
        //Input
        switch (settings.selectedInput) {
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
        if (!paused && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<blockController>().turnLeft();
        else if(paused && !controllerSettings.activeInHierarchy) deactivatePause();
    }

    public void buttonTurnRight() {
        if (!paused && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<blockController>().turnRight();
        else if (paused && !controllerSettings.activeInHierarchy) deactivatePause();
    }

    public void buttonRotate() {
        if (!paused && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<blockController>().rotate();
        else if (paused && !controllerSettings.activeInHierarchy) deactivatePause();
    }

    public void buttonSpeedUp() {
        if (!paused && !endGame.gameObject.activeInHierarchy) managerBlocks.getBlock().GetComponent<blockController>().speedUp = true;
        else if (paused && !controllerSettings.activeInHierarchy) deactivatePause();
    }

    public void activatePause() {
        paused = true;
        pauseTxt.SetActive(true);
    }

    public void deactivatePause() {
        paused = false;
        pauseTxt.SetActive(false);
    }

    public int getPoints() { return points.getPoints(); }

    private void selectedInputButtons() {
        if (!inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(true);
    }

    private void selectedInputTap() {
        if (inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(false);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if (!paused && !controllerSettings.activeInHierarchy && !endGame.gameObject.activeInHierarchy)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (touchPos.y < -3.3225f) managerBlocks.getBlock().GetComponent<blockController>().rotate();
                else {
                    if (touchPos.x > -0.95f && touchPos.x < 0.95f) managerBlocks.getBlock().GetComponent<blockController>().speedUp = true;
                    else if (touchPos.x < -0.95f) managerBlocks.getBlock().GetComponent<blockController>().turnLeft();
                    else if (touchPos.x > 0.95f) managerBlocks.getBlock().GetComponent<blockController>().turnRight();
                }
            }
            else if (paused && !controllerSettings.activeInHierarchy) deactivatePause();
        }
    }

    private void selectedInputSwipe() {
        if (inputButtons[0].activeInHierarchy) foreach (GameObject obj in inputButtons) obj.SetActive(false);

        if (Input.touchCount > 0) {
            if (!paused && !controllerSettings.activeInHierarchy && !endGame.gameObject.activeInHierarchy) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) touchStartPos = Input.GetTouch(0).position;
                else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                    touchEndPos = Input.GetTouch(0).position;

                    if (Mathf.Abs(touchEndPos.x - touchStartPos.x) > Mathf.Abs(touchEndPos.y - touchStartPos.y)) {
                        if (touchEndPos.x > touchStartPos.x) managerBlocks.getBlock().GetComponent<blockController>().turnRight();
                        else managerBlocks.getBlock().GetComponent<blockController>().turnLeft();
                    }
                    else {
                        if (touchEndPos.y > touchStartPos.y) managerBlocks.getBlock().GetComponent<blockController>().rotate();
                        else managerBlocks.getBlock().GetComponent<blockController>().speedUp = true;
                    }
                }
            }
            else if (paused && !controllerSettings.activeInHierarchy) deactivatePause();
        }
    }
}
