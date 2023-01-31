using UnityEngine;

namespace MyFlyBird
{
    public class RespawnObstacles : MonoBehaviour
    {
        [SerializeField] private GameObject[] _walls;
        [SerializeField] public Transform _startPoint;
        [SerializeField] private float _timeBetweenShots;
        [SerializeField] private float _startTimeShoot;

        private void Update()
        {
            CreateWall(_startPoint, _walls);
        }

        private void CreateWall(Transform _startPoint, GameObject[] _walls)
        {
            if (_timeBetweenShots <= 0)
            {
                var chooseWall = Random.Range(0, 3);
                Instantiate(_walls[chooseWall], _startPoint.position, Quaternion.identity);
                _timeBetweenShots = _startTimeShoot;
            }
            else _timeBetweenShots -= Time.deltaTime;
        }
    }
}
