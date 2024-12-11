using UnityEngine;

namespace DDREAMS.AUDIO
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioClipPlayer : MonoBehaviour
    {
        private bool _isActive = false;
        private AudioSource _audioSource;


        private const string ERROR__NO_AUDIOCLIP = "The AudioSource component doesn't contain an AudioClip. Please add an AudioClip.";


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            if (_audioSource.playOnAwake) _audioSource.playOnAwake = false;
        }

        private void Start()
        {
            if (_audioSource.clip == null)
            {
                Debug.LogWarning(ERROR__NO_AUDIOCLIP);
                return;
            }
        }

        private void Update()
        {
            if (!_isActive || _audioSource.isPlaying) return;

            CORE.AppManager.QuitApplication();
        }


        public void ActivateAudioClipPlayer()
        {
            if (_audioSource.clip != null)
            {
                _audioSource.Play();

                _isActive = true;
            }
        }
    }
}
