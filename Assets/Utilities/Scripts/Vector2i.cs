//TODO Need unity editor script to display/edit values in inspector

[System.Serializable]
public class Vector2i {
    private int _x, _y;

    public int x {
        get { return _x; }
        set { _x = value; }
    }

    public int y {
        get { return _y; }
        set { _y = value; }
    }

    public Vector2i() {
        x = 0;
        y = 0;
    }

    public Vector2i(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
