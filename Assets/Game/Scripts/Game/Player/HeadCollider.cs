using UnityEngine;

namespace Player
{
    public class HeadCollider : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Collider _legsCollider;
        private void OnTriggerEnter(Collider other) => _legsCollider.enabled = false;
    }
}
