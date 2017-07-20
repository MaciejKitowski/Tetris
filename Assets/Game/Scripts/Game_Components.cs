using UnityEngine;

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
}