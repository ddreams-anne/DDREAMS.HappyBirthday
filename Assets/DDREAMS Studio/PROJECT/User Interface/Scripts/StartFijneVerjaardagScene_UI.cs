using System.Collections;
using DDREAMS.AUDIO;
using UnityEngine;
using UnityEngine.UIElements;

namespace DDREAMS.HappyBirthday
{
    [RequireComponent(typeof(UIDocument))]
    public class StartFijneVerjaardagScene_UI : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Add a reference to an AudioClipPlayer component.")]
        private AudioClipPlayer _AudioClipPlayer;

        [SerializeField]
        [Tooltip("Add a reference to a BalloonSpawner component.")]
        private BalloonSpawner _BalloonSpawner;

        [SerializeField]
        [Tooltip("Add a reference to a RandomTextSwitcher component.")]
        private RandomTextSwitcher _RandomTextSwitcher;

        [SerializeField]
        [Tooltip("The delay in seconds before the scene starts, once the Start Button has been clicked upon.")]
        private float _StartSceneDelay = 0.5f;


        private Button _startButton = null;
        private UIDocument _uIDocument = null;


        private const string ERROR__NO_AUDIO_CLIP_PLAYER = "No reference to an AudioClipPlayer component found. Please add a reference to an AudioClipPlayer component.";
        private const string ERROR__NO_BALLOON_SPAWNER = "No referenceto to a BalloonSpawner component found. Please add a reference to a BalloonSpawner component.";
        private const string ERROR__NO_RANDOM_TEXT_SWITCHER = "No referenceto to a RandomTextSwitcher component found. Please add a reference to a RandomTextSwitcher component.";


        private void Awake()
        {
            if (_AudioClipPlayer == null)
            {
                Debug.LogWarning(ERROR__NO_AUDIO_CLIP_PLAYER);
                return;
            }

            if (_BalloonSpawner == null)
            {
                Debug.LogWarning(ERROR__NO_BALLOON_SPAWNER);
                return;
            }

            if (_RandomTextSwitcher == null)
            {
                Debug.LogWarning(ERROR__NO_RANDOM_TEXT_SWITCHER);
                return;
            }

            _uIDocument = GetComponent<UIDocument>();
            _startButton = _uIDocument.rootVisualElement.Q<Button>("StartButton");
        }

        private void Start()
        {
            if (_AudioClipPlayer == null || _BalloonSpawner == null || _RandomTextSwitcher == null) return;

            if (_startButton != null)
            {
                _startButton.clickable.clicked += () =>
                {
                    StartCoroutine(StartSceneWithDelay(_StartSceneDelay));
                    _startButton.visible = false;
                };
            }
        }


        IEnumerator StartSceneWithDelay(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);

            _BalloonSpawner.StartSpawningBalloons();
            _RandomTextSwitcher.StartSwitchingText();
            _AudioClipPlayer.ActivateAudioClipPlayer();
        }
    }
}
