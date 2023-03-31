using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    public class MoveObstacles : MonoBehaviour
    {
        private Rigidbody2D _rbObstacles;

        [Space, SerializeField, Range(0f ,10f)] private float _moveSpeedObstacles;
        [SerializeField] private float _timeToDestroy = 25f;

        private void Start()
        {
            _rbObstacles = GetComponent<Rigidbody2D>();

            StartCoroutine(CorotiuneMovement());
        }

        private void Update()
        {
            if (_timeToDestroy >= 0f) _timeToDestroy -= Time.deltaTime;
            else Destroy(gameObject);
        }

        private IEnumerator CorotiuneMovement()
        {
            while (true)
            {
                _rbObstacles.velocity = new Vector2 (-_moveSpeedObstacles, 0);
                yield return null;
            }
        }
    }
}
