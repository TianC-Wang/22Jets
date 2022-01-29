using UnityEngine;

namespace Tests.Components
{
    public class BulletFieldGenerator : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _min = Vector3.zero;
        [SerializeField]
        private Vector3 _max = Vector3.zero;
        [SerializeField]
        private int _countPerFrame = 5;
        [SerializeField]
        private float _chancePerFrame = .05f;
        [SerializeField]
        private GameObject _bulletPreset = null;
        [SerializeField]
        private SnapAxis _firingAxis = SnapAxis.None;
        private void Update()
        {
            if (Random.Range(0f, 1f) < _chancePerFrame)
                switch (_firingAxis)
                {
                    case SnapAxis.X:
                        for (int i = 0; i < _countPerFrame; i++)
                        {
                            GameObject bullet = Instantiate(_bulletPreset);
                            if (Random.Range(0, 2) == 0)
                                bullet.transform.position = _min + new Vector3(0f, Random.Range(0f, .5f) * (_max.y - _min.y), Random.Range(0f, 1f) * (_max.z - _min.z));
                            else
                                bullet.transform.position = _max - new Vector3(0f, Random.Range(.5f, 1f) * (_max.y - _min.y), Random.Range(0f, 1f) * (_max.z - _min.z));
                            bullet.GetComponent<Rigidbody>().velocity = ((_max + _min) / 2f - bullet.transform.position).normalized * 10f;
                            bullet.AddComponent<SimpleBullet>().SetOutRange(_min - Vector3.one * 255f, _max + Vector3.one * 255f);
                        }
                        break;
                    default:
                        break;
                }
        }
    }
}