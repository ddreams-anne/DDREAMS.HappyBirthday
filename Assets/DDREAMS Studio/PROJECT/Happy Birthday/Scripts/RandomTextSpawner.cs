using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace com.DDREAMS.HappyBirthday
{
    public class RandomTextSpawner : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Provide the text that will spawn randomly.")]
        private List<string> _RandomTextList;

        [SerializeField]
        [Tooltip("Provide the time in seconds to refresh the text.")]
        private float _DelayTime = 5.0f;

        private TextMeshPro _textMeshPro;


        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            if (_textMeshPro != null && _RandomTextList.Count > 0) StartCoroutine(SpawnRandomTextWithDelay());
        }


        IEnumerator SpawnRandomTextWithDelay()
        {
            while (true)
            {
                _textMeshPro.text = _RandomTextList[Random.Range(0, _RandomTextList.Count)];

                yield return new WaitForSeconds(_DelayTime);
            }
        }
    }
}
