using UnityEngine;

namespace Border
{
    public class BorderViewPort : MonoBehaviour
    {
        [SerializeField] private Player.PlayerController _playerController;
        [SerializeField] private Camera _camera;

        private void Update()
        {
            float viewX = _camera.WorldToViewportPoint(_playerController.transform.position).x;
            if (viewX > 1)
                _playerController.transform.position = new Vector3(_camera.ViewportPointToRay(Vector3.zero).GetPoint(Vector3.Distance(new Vector3(0, 0, _camera.transform.position.z), new Vector3(0, 0, _playerController.transform.position.z))).x, _playerController.transform.position.y, _playerController.transform.position.z);

            if (viewX < 0)
                _playerController.transform.position = new Vector3(_camera.ViewportPointToRay(Vector3.one).GetPoint(Vector3.Distance(new Vector3(0, 0, _camera.transform.position.z), new Vector3(0, 0, _playerController.transform.position.z))).x, _playerController.transform.position.y, _playerController.transform.position.z);
        }
    }
}