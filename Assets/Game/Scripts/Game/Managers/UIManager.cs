using UnityEngine;
using UnityEngine.SceneManagement;
using PrimeTween;
using TMPro;
using NaughtyAttributes;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField, BoxGroup("Death")] private RectTransform _deathPanel;
        [SerializeField, BoxGroup("Death")] private float _durationAnim;

        [SerializeField, BoxGroup("Score")] private TextMeshProUGUI _scoreText;
        [SerializeField, BoxGroup("Score")] private TextMeshProUGUI _lastScoreText;
        private int _score;

        private void Start() => UpdateScore(0);

        public void UpdateScore(int score)
        {
            _score = score;
            _scoreText.text = $"Score: {score}";
        }
        #region Panels
        public void OpenDeathPanel()
        {
            _deathPanel.gameObject.SetActive(true);
            _lastScoreText.text = $"Last Score: {_score}";
            Tween.UIAnchoredPositionY(_deathPanel, endValue: 0, duration: _durationAnim);
        }
        #endregion

        #region Buttons
        public void RestartButton() => SceneManager.LoadScene("GameScene");
        public void MenuButton() => SceneManager.LoadScene("MainMenu");
        #endregion
    }
}