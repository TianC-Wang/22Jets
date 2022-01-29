using UnityEngine;

namespace Tests.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleGun : MonoBehaviour
    {
        [SerializeField]
        private float _barrelLength = .3f;
        [SerializeField]
        private float _barrelSize = .05f;
        private Rigidbody _rigidbody = null;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Fire(float _Force, float _Mass)
        {
            GameObject bullet = Resources.Load<GameObject>("Prefabs/SimpleBullet.prefab");
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            bullet.transform.localScale = new(_barrelSize * 50f, _barrelSize * 50f, _barrelSize * 50f);
            bullet.transform.position = transform.position + transform.rotation * new Vector3(0f, 0f, _barrelLength);
            rigidbody.mass = _Mass;
            rigidbody.AddRelativeForce(new(0f, 0f, _Force), ForceMode.Impulse);
            _rigidbody.AddRelativeForce(new(0f, 0f, -_Force), ForceMode.Impulse);
        }
    }
}