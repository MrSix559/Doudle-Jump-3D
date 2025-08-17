using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NaughtyAttributes;
using SaveData;
using UnityEngine;

namespace Managers
{
    public class SoundManager : Singleton<SoundManager>
    {
        [System.Serializable]
        private class AudioVariant
        {
            public string Id;
            public AudioSource Prefab;
        }

        [SerializeField, BoxGroup("Sounds")] private AudioVariant[] _soundsPrefab;
        [SerializeField, BoxGroup("Music")] private AudioSource _music;
        private Dictionary<string, PoolComponents<AudioSource>> _soundsPool;

        public override void Awake()
        {
            base.Awake();
            _soundsPool = new();
            foreach (var sound in _soundsPrefab)
                _soundsPool.Add(sound.Id, new PoolComponents<AudioSource>(sound.Prefab));
        }

        public void SetSound(bool soundSet)
        {
            foreach (var sound in _soundsPool)
                foreach(var source in sound.Value.GetAll())
                    source.mute = !soundSet;
        }

        public void SetMusic(bool musicSet) => _music.mute = !musicSet;
        public void PlaySound(string id) => StartCoroutine(PlayTimerSource(_soundsPool[id].Get()));

        private IEnumerator PlayTimerSource(AudioSource source)
        {
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
            source.gameObject.SetActive(false);
        }

    }
}