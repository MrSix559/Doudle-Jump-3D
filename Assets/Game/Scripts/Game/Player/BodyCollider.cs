using UnityEngine;

namespace Player
{
    public class BodyCollider : MonoBehaviour
    {
        [SerializeField] private Collider _legsCollider;

        private void OnTriggerExit(Collider other) => _legsCollider.enabled = true;
    }
}
