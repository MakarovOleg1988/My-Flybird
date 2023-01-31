using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFlyBird
{
    public class MoveObstacles : MonoBehaviour
    {
        private Rigidbody2D _rbObstacles;

        [Space, SerializeField] private float _moveSpeedObstacles;

        private void Start()
        {
            _rbObstacles = GetComponent<Rigidbody2D>();

            StartCoroutine(CorotiuneMovement());
        }

        private IEnumerator CorotiuneMovement()
        {
            while (true)
            {
                _rbObstacles.velocity = new Vector2(-_moveSpeedObstacles, 0);
                yield return null;
            }
        }
    }
}
