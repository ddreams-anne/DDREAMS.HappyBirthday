using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDREAMS.HappyBirthday
{
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Provide at least one balloon prefab.")]
        private List<GameObject> _BalloonPrefabs;

        [SerializeField]
        [Tooltip("The number of balloons that need to be spawned.")]
        private int _NumberOfBalloons = 99;

        [SerializeField]
        [Tooltip("The minimum time in seconds between spawning a new balloon.")]
        private float _MinimumDelayTime = 0.25f;

        [SerializeField]
        [Tooltip("The maximum time in seconds between spawning a new balloon.")]
        private float _MaximumDelayTime = 0.5f;


        private const string ERROR__NO_BALLOON_PREFABS = "No balloon Prefabs are found for the BalloonSpawner. Please add at least one Prefab.";


        private void Awake()
        {
            if (_BalloonPrefabs.Count < 1)
            {
                Debug.LogWarning(ERROR__NO_BALLOON_PREFABS);
                return;
            }
        }


        public void StartSpawningBalloons()
        {
            StartCoroutine(SpawnBalloons());
        }


        IEnumerator SpawnBalloons()
        {
            GameObject newBalloon;

            for (int i = 0; i < _NumberOfBalloons; i++)
            {
                float delayTime = Random.Range(_MinimumDelayTime, _MaximumDelayTime);

                newBalloon = Instantiate(_BalloonPrefabs[Random.Range(0, _BalloonPrefabs.Count)]);
                newBalloon.name = $"Balloon {i.ToString("000")}";
                newBalloon.transform.parent = transform;

                yield return new WaitForSeconds(delayTime);
            }
        }
    }
}
