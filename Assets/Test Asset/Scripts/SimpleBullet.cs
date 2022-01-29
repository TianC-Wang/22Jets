using UnityEngine;

namespace Tests.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleBullet : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _minPos = Vector3.zero;
        [SerializeField]
        private Vector3 _maxPos = Vector3.zero;
        private Rigidbody _rigidbody = null;
        private void DeleteOnOutRange()
        {
            if (transform.position.x < _minPos.x ||
                transform.position.y < _minPos.y ||
                transform.position.z < _minPos.z ||
                transform.position.x > _maxPos.x ||
                transform.position.y > _maxPos.y ||
                transform.position.z > _maxPos.z)
                Destroy(gameObject);
        }
        public void SetOutRange(Vector3 _Min, Vector3 _Max)
        {
            _minPos = _Min;
            _maxPos = _Max;
        }
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            DeleteOnOutRange();
        }
    }
}