using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDREAMS.AUDIO
{
    public class RandomAudioClipPlayer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Add two AudioSource components to the GameObject.")]
        private List<AudioClip> _AudioClips;

        [SerializeField]
        [Tooltip("The time to delay the loading of the new AudioClip to prevent CPU spikes (in seconds).")]
        private float _LoadAudioClipDelay = 5.0f;


        private const string ERROR__NO_AUDIOSOURCES = "Two AudioSource components are required for smooth transitions between two AudioClips. Please check to see if two AudioSource components are added to this GameObject.";
        private const string ERROR__NO_AUDIOCLIPS = "No AudioClips found. Please add at least two AudioCLips or use the AudioClipPlayer component instead.";
        private const string ERROR__NOT_ENOUGH_AUDIOCLIPS = "Not enough AudioClips found. Please add at least two AudioCLips or use the AudioClipPlayer component instead.";


        private bool _isActive = false;
        private bool _isPlaying = false;
        private int _audioSourceIndex = 0;
        private AudioSource[] _audioSources;
        private List<AudioClip> _playList;


        private void Awake()
        {
            _audioSources = GetComponents<AudioSource>();

            // Two AudioSource components are required to enable smooth transitions between AudioClips, and prevent sudden CPU spikes.
            if (_audioSources.Length < 2)
            {
                Debug.LogWarning(ERROR__NO_AUDIOSOURCES);
                return;
            }

            _playList = new List<AudioClip>(_AudioClips);
        }

        private void Update()
        {
            if (!_isActive || _audioSources[_audioSourceIndex].isPlaying) return;

            PlayRandomAudioClip();
        }


        public void ActivateRandomAudioClipPlayer()
        {
            _isActive = true;
        }


        private AudioClip GetRandomAudioClip()
        {
            if (_AudioClips.Count == 0)
            {
                Debug.LogWarning(ERROR__NO_AUDIOCLIPS);
                return null;
            }

            if (_AudioClips.Count == 1)
            {
                Debug.LogWarning(ERROR__NOT_ENOUGH_AUDIOCLIPS);
                return null;
            }

            int audioClipIndex = Random.Range(0, _playList.Count);
            AudioClip newAudioClip = _playList[audioClipIndex];

            _playList.RemoveAt(audioClipIndex);

            if (_playList.Count == 0) _playList = new List<AudioClip>(_AudioClips);

            return newAudioClip;
        }

        private void PlayRandomAudioClip()
        {
            if (!_isPlaying)
            {
                _audioSources[0].clip = GetRandomAudioClip();
                _audioSources[1].clip = GetRandomAudioClip();
                _audioSources[_audioSourceIndex].Play();
                _isPlaying = true;
            }
            else
            {
                _audioSourceIndex = 1 - _audioSourceIndex;
                _audioSources[_audioSourceIndex].Play();

                StartCoroutine(AddAudioClipToAudioSource());
            }
        }

        private IEnumerator AddAudioClipToAudioSource()
        {
            yield return new WaitForSeconds(_LoadAudioClipDelay);

            _audioSources[1 - _audioSourceIndex].clip = GetRandomAudioClip();
        }
    }
}
