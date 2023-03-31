using UnityEngine;

namespace MyFlyBird
{
    public class RespawnClouds : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _clouds;
        [SerializeField] public Transform _startPoint;
        [SerializeField] private float _timeBetweenShots;
        [SerializeField] private float _startTimeShoot;

        private void Update()
        {
            CreateClouds(_startPoint, _clouds);
        }

        private void CreateClouds(Transform _startPoint, SpriteRenderer[] _clouds)
        {
            if (_timeBetweenShots <= 0)
            {
                int chooseClouds = Random.Range(0, 3);
                SpriteRenderer cloud = Instantiate(_clouds[chooseClouds], _startPoint.position + new Vector3(0f, Random.Range(-4f, 4f), 0f), Quaternion.identity);
                cloud.transform.parent = transform;
                _timeBetweenShots = _startTimeShoot;
            }
            else _timeBetweenShots -= Time.deltaTime;
        }
    }
}
