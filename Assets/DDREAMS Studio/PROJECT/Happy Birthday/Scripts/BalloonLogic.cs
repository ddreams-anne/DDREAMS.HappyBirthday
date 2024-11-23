using System.Collections.Generic;
using UnityEngine;

namespace com.DDREAMS.HappyBirthday
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ConstantForce))]
    public class BalloonLogic : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Provide a list of materials or the balloons.")]
        private List<Material> _BalloonMaterials;


        private float _gravity = 9.81f;
        private Rigidbody _rigidBody;
        private Transform _originalPosition;
        private ConstantForce _constantForce;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _constantForce = GetComponent<ConstantForce>();
        }


        private void Update()
        {
            if (transform.position.y > 20.0f) InitializeBalloon();
        }

        private void Start()
        {
            _originalPosition = transform.parent.parent;

            InitializeBalloon();
        }


        public void InitializeBalloon()
        {
            _rigidBody.linearVelocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;

            _gravity = Random.Range(0.1f, 0.5f);
            _constantForce.force = new(0.0f, _gravity, 0.0f);

            if (_BalloonMaterials.Count > 0) transform.GetChild(1).GetComponent<Renderer>().material = _BalloonMaterials[Random.Range(0, _BalloonMaterials.Count)];

            transform.position = _originalPosition.position + new Vector3(Random.Range(-17.5f, 17.5f), 0.0f, (Random.Range(0, 2) == 0) ? Random.Range(-5.0f, -0.4f) : Random.Range(0.4f, 5.0f));
        }
    }
}
