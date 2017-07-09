using UnityEngine;

public class Arena : MonoBehaviour {
    private ArenaTile[,] _tile;
    private int maxTileX;
    private int maxTileY;

    public ArenaTile[,] tile { get { return _tile; } private set { _tile = value; } }

    void Awake() {
        maxTileY = transform.childCount;
        maxTileX = transform.GetChild(0).childCount;
        tile = new ArenaTile[maxTileX, maxTileY];

        for(int y = 0; y < maxTileY; ++y) {
            for(int x = 0; x < maxTileX; ++x) {
                tile[x, y] = transform.GetChild(y).GetChild(x).GetComponent<ArenaTile>();
            }
        }
    }
}
