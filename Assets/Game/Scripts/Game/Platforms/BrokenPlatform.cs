using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Platforms
{
    public class BrokenPlatform : Platform, IPlatform
    {
        [SerializeField, Foldout("Events")] private UnityEvent _breakPlatfrom;
        [SerializeField, Foldout("Events")] private UnityEvent _resetPlatform;

        [SerializeField] private Rigidbody[] _parts;
        private Vector3[] _partsStartPos;

        private void Awake()
        {
            _partsStartPos = new Vector3[_parts.Length];
            for (int i = 0; i < _partsStartPos.Length; i++)
            {
                _partsStartPos[i] = _parts[i].transform.localPosition;
            }
        }

        public new void Interactive()
        {
            _breakPlatfrom?.Invoke();
            Managers.SoundManager.Instance.PlaySound("BrokenPlatform");
            StartCoroutine(ResetPlatform());
        }

        private IEnumerator ResetPlatform()
        {
            yield return new WaitForSeconds(6);
            for (int i = 0; i < _parts.Length; i++)
            {
                _parts[i].transform.localPosition = _partsStartPos[i];
                _parts[i].linearVelocity = Vector3.zero;
            }
            _resetPlatform.Invoke();
        }
    }
}