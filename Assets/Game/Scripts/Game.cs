﻿using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField] private Game_components.Tetromino _tetromino;
    [SerializeField] private Game_components.Level _level;
    [SerializeField] private Game_components.Point _points;

    public Game_components.Tetromino tetromino { get { return _tetromino; } }
    public Game_components.Level level { get { return _level; } }
    public Game_components.Point points { get { return _points; } }

    void Start() {
        points.setPoints(0);
    }

    public void addPoints() {
        points.addPoints();
        level.rowRemoved();
    }
}