using System.Collections.Generic;
using UnityEngine;

namespace DDREAMS.HappyBirthday
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ConstantForce))]
    public class BalloonLogic : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Provide a list of materials for the balloons.")]
        private List<Material> _BalloonMaterials;

        [SerializeField]
        [Tooltip("Minimum refresh position on the X-axis (from to the spawner position).")]
        private float _MinimumRefreshPositionX = -30.0f;

        [SerializeField]
        [Tooltip("Minimum refresh position on the X-axis (from to the spawner position).")]
        private float _MaximumRefreshPositionX = 30.0f;

        [SerializeField]
        [Tooltip("Minimum refresh position on the Y-axis (from to the spawner position).")]
        private float _MinimumRefreshPositionY = -20.0f;

        [SerializeField]
        [Tooltip("Minimum refresh position on the Y-axis (from to the spawner position).")]
        private float _MaximumRefreshPositionY = 0.0f;

        [SerializeField]
        [Tooltip("Minimum refresh position on the Z-axis (from to the spawner position).")]
        private float _MinimumRefreshPositionZ = 0.4f;

        [SerializeField]
        [Tooltip("Minimum refresh position on the Z-axis (from to the spawner position).")]
        private float _MaximumRefreshPositionZ = 5.0f;


        private const string ERROR__NO_BALLOON_MATERIALS = "No referenceto to balloon Materials could be found. Please add at least one balloon Material reference.";


        private float _gravity = 9.81f;
        private Transform _originalPosition;
        private Rigidbody _rigidBody;
        private ConstantForce _constantForce;


        private void Awake()
        {
            if (_BalloonMaterials == null)
            {
                Debug.LogWarning(ERROR__NO_BALLOON_MATERIALS);
                return;
            }

            _rigidBody = GetComponent<Rigidbody>();
            _constantForce = GetComponent<ConstantForce>();
        }

        private void Start()
        {
            if (_BalloonMaterials == null || _BalloonMaterials.Count == 0) return;

            _originalPosition = transform.parent;

            InitializeBalloon();
        }

        private void Update()
        {
            if (_BalloonMaterials == null || _BalloonMaterials.Count == 0) return;
            if (transform.position.y > 20.0f) InitializeBalloon();
        }


        private void InitializeBalloon()
        {
            _rigidBody.linearVelocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;

            _gravity = Random.Range(0.1f, 0.5f);
            _constantForce.force = new(0.0f, _gravity, 0.0f);

            if (_BalloonMaterials.Count > 0) transform.GetChild(1).GetComponent<Renderer>().material = _BalloonMaterials[Random.Range(0, _BalloonMaterials.Count)];

            transform.position = _originalPosition.position + new Vector3(Random.Range(_MinimumRefreshPositionX, _MaximumRefreshPositionX), Random.Range(_MinimumRefreshPositionY, _MaximumRefreshPositionY), (Random.Range(0, 2) == 0) ? Random.Range(-_MaximumRefreshPositionZ, -_MinimumRefreshPositionZ) : Random.Range(_MinimumRefreshPositionZ, _MaximumRefreshPositionZ));
            transform.rotation = Quaternion.identity;
        }
    }
}
