using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DDREAMS.HappyBirthday
{
    [RequireComponent(typeof(UIDocument))]
    public class RandomTextSwitcher : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Provide text that will switch randomly.")]
        private List<string> _RandomTextList;

        [SerializeField]
        [Tooltip("Provide the time in seconds to refresh the text.")]
        private float _DelayTime = 5.0f;


        private UIDocument _uiDocument;
        private Label _happyBirtdayText = null;


        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _happyBirtdayText = _uiDocument.rootVisualElement.Q<Label>("HappyBirthdayText");
        }


        public void StartSwitchingText()
        {
            if (_happyBirtdayText != null && _RandomTextList.Count > 0) StartCoroutine(SwitchTextWithDelay());
        }


        IEnumerator SwitchTextWithDelay()
        {
            while (true)
            {
                _happyBirtdayText.text = _RandomTextList[Random.Range(0, _RandomTextList.Count)];

                yield return new WaitForSeconds(_DelayTime);
            }
        }
    }
}
