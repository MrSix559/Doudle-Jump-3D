using UnityEngine;

namespace Player
{
    public class LegsCollider : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<IPlatform>(out IPlatform platform))
                platform.Interactive();

            _playerController.Jump();
            _playerController.JumpParticlePlay(platform.ColorPlatform());
        }
    }
}
