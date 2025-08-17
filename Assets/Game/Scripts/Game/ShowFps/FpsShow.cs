using TMPro;
using UnityEngine;

namespace ShowFps
{
    public class FpsShow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _fpsText;
        private void Update() => _fpsText.text = $"FPS: {(int)(1.0f / Time.deltaTime)}";
        public void SetEnabledText(bool status) => _fpsText.gameObject.SetActive(status);
    }
}
