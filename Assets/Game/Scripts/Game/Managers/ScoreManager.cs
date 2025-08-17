using System.Collections;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private float _nowScore;
        private float _maxScore;

        private void Start()
        {
            StartCoroutine(CheckScore());
        }

        private void AddScore(int Score) => UIManager.Instance.UpdateScore(Score);

        private IEnumerator CheckScore()
        {
            WaitForSeconds secondsForCheck = new WaitForSeconds(0.5f);
            while (true)
            {
                yield return secondsForCheck;

                _nowScore = _player.position.y;

                if (_nowScore > _maxScore)
                {
                    AddScore(Mathf.RoundToInt(_nowScore));
                    _maxScore = _nowScore;
                }
            }
        }

    }
}