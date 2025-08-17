using UnityEngine;

namespace Pause
{
    public class PauseButton : MonoBehaviour
    {
        public void PauseBut(GameObject panelPause) => panelPause?.SetActive(true);
        public void ResumeBut(GameObject panelPause) => panelPause?.SetActive(false);
    }
}