using UnityEngine;

public class ArenaTile : MonoBehaviour {
    [SerializeField]
    private bool _empty = true;

    public bool empty { get { return _empty; } private set { _empty = value; } }
}
