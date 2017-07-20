using UnityEngine;
using UnityEngine.UI;

namespace Game_components {
    [System.Serializable]
    public class Tetromino {
        [SerializeField] private float _fallTime = 1.0f;
        [SerializeField] private float _boostMultiplier = 0.1f;
        
        public float fallTime { get { return _fallTime; } }
        public float fallTimeBoosted { get { return _fallTime * _boostMultiplier; } }
    }

    [System.Serializable]
    public class Level {
        [SerializeField] private CircleBar bar;
        [SerializeField] private int rowsToLevel = 5;

        public void rowRemoved() { bar.raiseProgress(1f / rowsToLevel); }
    }

    [System.Serializable]
    public class Point {
        [SerializeField] private Text displayValue;
        [SerializeField] private int pointsPerRow = 15;
        private int _points;

        public int points {
            get { return _points; }
            set {
                _points = value;
                displayValue.text = value.ToString();
            }
        }

        public void setPoints(int val) { points = val; }
        public void addPoints() { points += pointsPerRow; }
    }
}