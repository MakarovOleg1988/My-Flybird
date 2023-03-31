using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    public class RespawnObstacles : ObstaclesParam
    {

        private void Start()
        {
            StartCoroutine(CoroutineBust(_bustSpeedSpawn));
        }

        private void Update()
        {
            CreateWall(_startPoint, _walls);
        }

        private void CreateWall(Transform _startPoint, GameObject[] _walls)
        {
            if ((_timeBetweenShots - _bustSpeedSpawn) <= 0)
            {
                int chooseWall = Random.Range(0, _walls.Length - 1);
                GameObject wall = Instantiate(_walls[chooseWall], _startPoint.position, Quaternion.identity);
                wall.transform.parent = transform;

                _timeBetweenShots = _startTimeShoot;
            }
            else _timeBetweenShots -= Time.deltaTime;
        }

        private IEnumerator CoroutineBust(float _bustSpeedSpawn)
        {
            while (true)
            {
                _bustSpeedSpawn = _bustSpeedSpawn + _bustSpeedSpawn;
                yield return new WaitForSeconds(_timeBetweenBustForce);
            }
        }
    }
}
