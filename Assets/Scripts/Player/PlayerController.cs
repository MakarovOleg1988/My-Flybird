using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    public class PlayerController : MonoBehaviour
    {
        private NewControls _controls;
        [SerializeField] private Rigidbody2D _rbPlayer;

        [Space, SerializeField, Range(1f, 20f)] private float _jumpForce;
        [SerializeField, Range(1f, 15f)] private float _timeBetweenBustForce;
        [SerializeField, Range(1f, 4f)] private float _bustForce;

        private void Awake()
        {
            NewControls _controls = new NewControls();
            _controls.NewActionMap.Jump.performed += _ => Jump();
        }

        private void Start()
        {
            _rbPlayer = GetComponent<Rigidbody2D>();

            StartCoroutine(bustingJumpForce());
        }

        private void Update()
        {
            Jump();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _rbPlayer.AddForce(transform.up * (_jumpForce + _bustForce), ForceMode2D.Impulse);
        }

        private IEnumerator bustingJumpForce()
        {
            while (true)
            {
                _bustForce = _bustForce + 1;
                yield return new WaitForSeconds(_timeBetweenBustForce);
            }
        }
    }
}
