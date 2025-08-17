using UnityEngine;

namespace Platforms
{
    [RequireComponent(typeof(BoxCollider))]
    public class Platform : MonoBehaviour, IPlatform
    {
        public Color _colorPlatform;

        public void Interactive()
        {
        
        }

        public Color ColorPlatform() => _colorPlatform;
    }
}