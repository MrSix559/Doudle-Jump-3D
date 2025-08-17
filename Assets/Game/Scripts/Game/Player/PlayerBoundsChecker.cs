using System;
using UnityEngine;

namespace Player
{
    public class PlayerBoundsChecker : MonoBehaviour
    {
        public static event Action OnDeath;

        [SerializeField] private Transform _camera;
        [SerializeField] private float _fallDistance = 5f;
        private float _maxHeight;
        private Transform _player => transform;
        private enum LifeState
        {
            Life,
            Died
        };
        private LifeState _lifeState;
        private void LateUpdate()
        {
            if(_lifeState == LifeState.Died)
                return;

            _maxHeight = Mathf.Max(_maxHeight, _player.position.y);
            if(_player.position.y < _maxHeight - _fallDistance)
            {
                _lifeState = LifeState.Died;
                OnDeath?.Invoke();
            }
        }
    }
}
