using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveFruits : MonoBehaviour
    {
        private Rigidbody2D _rbFruits;

        [Space, SerializeField, Range(0f ,10f)] 
        private float _moveSpeedFruits;
        
        [SerializeField] 
        private float _timeToDestroy = 25f;

        private void Start()
        {
            _rbFruits = GetComponent<Rigidbody2D>();
            _rbFruits.gravityScale = 0f;
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
                _rbFruits.velocity = new Vector2 (-_moveSpeedFruits, 0);
                yield return null;
            }
        }
    }
}
