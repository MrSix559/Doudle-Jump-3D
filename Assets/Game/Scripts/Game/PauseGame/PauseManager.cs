using System.Collections.Generic;
using UnityEngine;

namespace Pause
{
    public class PauseManager : Singleton<PauseManager>
    {
        private readonly List<IPausable> _pausables = new List<IPausable>();

        public void Register(IPausable pausable)
        {
            if (!_pausables.Contains(pausable))
                _pausables.Add(pausable);
        }

        public void UnRegister(IPausable pausable)
        {
            _pausables.Remove(pausable);
        }

        public void SetPaused(bool paused)
        {
            foreach (var p in _pausables)
            {
                if (paused) p.OnPause();
                else p.OnResume();
            }
        }
    }
}