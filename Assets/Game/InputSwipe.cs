using UnityEngine;
using System.Collections;

public class InputSwipe : MonoBehaviour {
    private bool activated = false;

    public void activate() { activated = true; }
    public void deactivate() { activated = false; }
}
