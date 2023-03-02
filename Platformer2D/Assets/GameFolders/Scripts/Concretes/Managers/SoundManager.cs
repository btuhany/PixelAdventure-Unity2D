using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

namespace Managers
{
    public class SoundManager : SingletonObject<SoundManager>
    {
        AudioSource[] _audioSource;
        float[] _volumes = new float[10];
        private void Awake()
        {
            SingletonThisObject(this);
            _audioSource = GetComponentsInChildren<AudioSource>();
        }
        private void Start()
        {
            //StartCoroutine(InitialVolumes());
        }
        public float GetInitialVolume(int index)
        {
            return _volumes[index];
        }
        public void PlaySound(int index)
        {
            if (!_audioSource[index].isPlaying)
            {
                _audioSource[index].volume = _volumes[index];
                _audioSource[index].Play();
            }
        }
        public void StopSound(int index, float fadeSpeed)
        {
            if (_audioSource[index].isPlaying)
            {

                //StartCoroutine(FadeOut(index, fadeSpeed));
                _audioSource[index].Stop();
            }
        }


        public void SetVolume(int index, float newVolume)
        {
            _volumes[index] = newVolume;
        }
        public void StopAllSounds()
        {
            foreach (var audio in _audioSource)
                audio.Stop();
        }
        public void PlaySoundWithDelay(int index, float delay)
        {
            if (!_audioSource[index].isPlaying)
            {
                _audioSource[index].volume = _volumes[index];
                _audioSource[index].PlayDelayed(delay);
            }

        }

        //FadeOut prevents the popping sound after the stopping the sound.
        //IEnumerator FadeOut(int index, float fadeSpeed)
        //{

        //    while (_audioSource[index].volume > 0.01f)
        //    {

        //        _audioSource[index].volume = _audioSource[index].volume - Time.deltaTime / fadeSpeed;
        //        yield return null;
        //    }

        //    if (_audioSource[index].volume <= 0.01f)
        //        _audioSource[index].Stop();




        //}

        //IEnumerator InitialVolumes()
        //{
        //    for (int i = 0; i < _audioSource.Length; i++)
        //    {
        //        _volumes[i] = _audioSource[i].volume;
        //    }
        //    yield return null;
        //}
    }
}