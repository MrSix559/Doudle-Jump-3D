using UnityEngine;
using NaughtyAttributes;

namespace Player
{
    public class PlayerController : MonoBehaviour, IPausable
    {
        #region Devices
        public enum DeviceType
        {
            PC,
            Mobile
        }
        [BoxGroup("Devices")] public DeviceType deviceType;
        #endregion
        #region PlayerSettings
        [SerializeField, Required, BoxGroup("Player Settings")] private Transform _playerModel;
        [SerializeField, Min(1), BoxGroup("Player Settings")] private float _moveSpeed;
        [SerializeField, Min(1), BoxGroup("Player Settings")] private float _jumpPower;
        #endregion
        #region Effects
        [SerializeField, Required, BoxGroup("Effects")] private ParticleSystem _jumpEffect;
        [SerializeField, Required, BoxGroup("Effects")] private Renderer _jumpEffectMat;
        #endregion
        #region Player States
        [SerializeField, BoxGroup("Player States"), ReadOnly] private bool _isControlling;
        private bool _isPaused;
        #endregion

        private Rigidbody _rb;
        private float _horizontalInput;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _jumpEffectMat.material = new Material(_jumpEffectMat.sharedMaterial);
        }

        private void OnEnable()
        {
            PlayerBoundsChecker.OnDeath += Death;
            Pause.PauseManager.Instance.Register(this);
        }

        private void OnDisable()
        {
            PlayerBoundsChecker.OnDeath -= Death;
            Pause.PauseManager.Instance.UnRegister(this);
        }

        private void Start()
        {
            _isControlling = true;
        }

        private void Update()
        {
            if (_isPaused || !_isControlling) return;

            if (deviceType == DeviceType.PC) _horizontalInput = Input.GetAxisRaw("Horizontal");
            if (deviceType == DeviceType.Mobile)
            {
                float tilt = Input.acceleration.x;
                _horizontalInput = Mathf.Clamp(tilt, -1f, 1f);
            }
            UpdatePlayerFacing();
        }

        private void FixedUpdate()
        {
            if (_isPaused) return;

            Vector3 velocity = _rb.linearVelocity;
            velocity.x = Mathf.Lerp(velocity.x, _horizontalInput * _moveSpeed, 0.1f);
            _rb.linearVelocity = velocity;
        }
        private void UpdatePlayerFacing()
        {
            if (_horizontalInput == 0 || !_isControlling) return;

            _playerModel.rotation = Quaternion.Euler(0, _horizontalInput > 0 ? 90f : -90f, 0);
        }

        public void Jump()
        {
            if (!_isControlling || _isPaused) return;

            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            Managers.SoundManager.Instance.PlaySound("Jump");
        }

        public void JumpParticlePlay(Color colorParticle)
        {
            _jumpEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            _jumpEffectMat.sharedMaterial.color = colorParticle;
            _jumpEffect.Play();
        }

        private void Death()
        {
            Managers.UIManager.Instance.OpenDeathPanel();
            Managers.SoundManager.Instance.PlaySound("Death");
            _horizontalInput = 0;
            _isControlling = false;
        }

        public void OnPause()
        {
            _isPaused = true;
            _rb.isKinematic = true;
        }

        public void OnResume()
        {
            _isPaused = false;
            _rb.isKinematic = false;
        }
    }
}