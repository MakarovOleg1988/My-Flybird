using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    public class MoveClouds : MonoBehaviour
    {
        private Rigidbody2D _rbClouds;

        [Space, SerializeField] private float _moveSpeedClouds;
        [SerializeField] private float _timeToDestroy = 25f;

        private void Start()
        {
            _rbClouds = GetComponent<Rigidbody2D>();

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
                _rbClouds.velocity = new Vector2(-_moveSpeedClouds, 0);
                yield return null;
            }
        }
    }
}
