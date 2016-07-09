using UnityEngine;

public class CreatorTile : MonoBehaviour {
    public bool pressed = false;

    private SpriteRenderer sprite;

    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.gray;
    }

    void OnMouseDown() {
        if(pressed) {
            pressed = false;
            sprite.color = Color.gray;
        }
        else {
            pressed = true;
            sprite.color = Color.green;
        }

    }
}
