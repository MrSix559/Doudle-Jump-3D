using UnityEngine;

namespace Player
{
    public class PlayerCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _followSpeed = 5f;

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
                Mathf.Max(_target.position.y, transform.position.y), transform.position.z),
                _followSpeed * Time.deltaTime);
        }
    }
}