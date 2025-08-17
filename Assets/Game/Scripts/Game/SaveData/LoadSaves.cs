using NaughtyAttributes;
using UnityEngine;

namespace SaveData
{
    public class LoadSaves : MonoBehaviour
    {
        [SerializeField, Required] private ShowFps.FpsShow _fpsShow;

        private void Start() => Load();
        public void Load()
        {
            #region FPS
            Application.targetFrameRate = SaveService.LoadFps();
            _fpsShow.SetEnabledText(SaveService.LoadFpsShow());
            #endregion

            #region Sound
            Managers.SoundManager.Instance.SetSound(SaveService.LoadSound());
            Managers.SoundManager.Instance.SetMusic(SaveService.LoadMusic());
            #endregion
        }
    }
}