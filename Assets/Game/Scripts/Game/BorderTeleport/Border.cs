using UnityEngine;
using NaughtyAttributes;

namespace Border
{
    public class Border : MonoBehaviour
    {
        [SerializeField, BoxGroup("Settings Border"), Required] private Transform _toTeleport;
        [SerializeField, BoxGroup("Settings Border"), Layer] private int _playerLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                other.transform.position = new Vector3(
                    _toTeleport.position.x,
                    other.transform.position.y,
                    other.transform.position.z
                );
            }
        }
    }
}