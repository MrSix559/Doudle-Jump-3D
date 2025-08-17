using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class SettingsManager : MonoBehaviour
    {
        #region FPS
        [SerializeField, Required, BoxGroup("Fps Settings")] private Toggle _fps60Toogle;
        [SerializeField, Required, BoxGroup("Fps Settings")] private Toggle _fps120Toogle;
        [SerializeField, Required, BoxGroup("Fps Settings")] private Toggle _showFpsToggle;
        [SerializeField, Required, BoxGroup("Fps Settings")] private ShowFps.FpsShow _fpsShow;
        #endregion

        #region Sound
        [SerializeField, Required, BoxGroup("Sound Settings")] private Toggle _soundToggle;
        [SerializeField, Required, BoxGroup("Sound Settings")] private Toggle _musicToggle;
        [SerializeField, Required, BoxGroup("Sound Settings")] private AudioSource _music;
        #endregion

        private void Awake()
        {
            InitializeFps();
            InitializeSound();
        }

        #region Fps Change
        private void InitializeFps()
        {
            int Fps = SaveData.SaveService.LoadFps();

            _fps60Toogle.SetIsOnWithoutNotify(Fps == 60);
            _fps120Toogle.SetIsOnWithoutNotify(Fps == 120);
            _showFpsToggle.SetIsOnWithoutNotify(SaveData.SaveService.LoadFpsShow());
        }

        public void On60Fps(bool isOn)
        {
            isOn = _fps60Toogle.isOn;
            Application.targetFrameRate = isOn ? 60 : 120;
            EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 60 : 120);
        }

        public void On120Fps(bool isOn)
        {
            isOn = _fps120Toogle.isOn;
            Application.targetFrameRate = isOn ? 120 : 60;
            EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 120 : 60);
        }

        public void OnShowFps(bool isOn)
        {
            isOn = _showFpsToggle.isOn;
            _fpsShow.SetEnabledText(isOn ? true : false);
            EncryptedPlayerPrefs.SetEncryptedInt("FpsShow", isOn ? 1 : 0);
        }
        #endregion

        #region Sound Set
        private void InitializeSound()
        {
            _musicToggle.SetIsOnWithoutNotify(SaveData.SaveService.LoadMusic());
            _soundToggle.SetIsOnWithoutNotify(SaveData.SaveService.LoadSound());
        }
        public void Music(bool isOn)
        {
            isOn = _musicToggle.isOn;
            SoundManager.Instance.SetMusic(isOn);
            EncryptedPlayerPrefs.SetEncryptedInt("Music", isOn ? 1 : 0);
        }

        public void Sound(bool isOn)
        {
            isOn = _soundToggle.isOn;
            SoundManager.Instance.SetSound(isOn);
            EncryptedPlayerPrefs.SetEncryptedInt("Sound", isOn ? 1 : 0);
        }


        #endregion
    }
}