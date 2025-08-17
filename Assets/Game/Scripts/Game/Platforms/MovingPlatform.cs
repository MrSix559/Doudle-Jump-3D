using UnityEngine;
using NaughtyAttributes;
using PrimeTween;

namespace Platforms
{
    public class MovingPlatform : Platform, IPausable
    {
        #region Direction
        [SerializeField, BoxGroup("Direction")] private Transform _startMovePos;
        [SerializeField, BoxGroup("Direction")] private Transform _endMovePos;
        #endregion
        #region Settings Move
        [SerializeField, BoxGroup("Settings Move"), Label("Animation Curve")] private AnimationCurve _animCurve;
        #endregion

        private Tween _moveToEnd;
        private Tween _moveToStart;

        private void OnEnable()
        {
            Pause.PauseManager.Instance.Register(this);
        }

        private void OnDisable()
        {
            Pause.PauseManager.Instance.UnRegister(this);
        }

        private void Start() => MoveToEnd();
        private void MoveToEnd() => _moveToEnd = Tween.PositionX(transform, _endMovePos.position.x, duration: 2f, _animCurve).OnComplete(MoveToStart);
        private void MoveToStart() => _moveToStart = Tween.PositionX(transform, _startMovePos.position.x, duration: 2f, _animCurve).OnComplete(MoveToEnd);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_startMovePos.position, _endMovePos.position);
        }

        public void OnPause()
        {
            _moveToEnd.isPaused = true;
            _moveToStart.isPaused = true;
        }

        public void OnResume()
        {
            _moveToEnd.isPaused = false;
            _moveToStart.isPaused = false;
        }
    }
}