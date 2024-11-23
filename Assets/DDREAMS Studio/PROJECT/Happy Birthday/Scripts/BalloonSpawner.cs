using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.DDREAMS.HappyBirthday
{
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _Balloon;

        [SerializeField]
        public int _NumberOfBalloons = 80;

        private List<GameObject> _Balloons;


        private void Start()
        {
            StartCoroutine(SpawnBalloons());
        }

        IEnumerator SpawnBalloons()
        {
            GameObject newBalloon;

            for (int i = 0; i < _NumberOfBalloons; i++)
            {
                float delayTime = Random.Range(0.25f, 0.5f);

                newBalloon = Instantiate(_Balloon);
                newBalloon.name = $"Balloon {i.ToString("000")}";
                newBalloon.transform.parent = transform;

                yield return new WaitForSeconds(delayTime);
            }
        }
    }
}
