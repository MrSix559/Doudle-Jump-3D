using UnityEngine;

namespace MenuSound
{
    public class SoundSetState
    {
        public void SoundState(bool status, AudioSource source) => source.mute = !status;
        public void MusicState(bool status, AudioSource source) => source.mute = !status;
    }
}