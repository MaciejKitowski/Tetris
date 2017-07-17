using UnityEngine;

namespace Game_components {
    [System.Serializable]
    public class Tetromino {
        [SerializeField] private float _fallTime = 1.0f;
        [SerializeField] private float _boostMultiplier = 0.1f;
        
        public float fallTime { get { return _fallTime; } }
        public float fallTimeBoosted { get { return _fallTime * _boostMultiplier; } }
    }
}