using System.Collections;
using UnityEngine;

namespace MyFlyBird
{
    public class PlayerController : PlayerParam
    {
        private void Awake()
        {
            NewControls _controls = new NewControls();
            _controls.NewActionMap.Jump.performed += _ => Jump();
        }

        private void Start()
        {
            _playerAvatar = GetComponent<SpriteRenderer>();
            _rbPlayer = GetComponent<Rigidbody2D>();

            ChooseBird();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        private void ChooseBird()
        {
            if (PlayerPrefs.GetInt("_chooseAvatar") == 1) _playerAvatar.sprite = _blueBirdImage;
            else if (PlayerPrefs.GetInt("_chooseAvatar") == 2) _playerAvatar.sprite = _pinkBirdImage;
        }

        public void Jump()
        {
            StartCoroutine(coroutineJump());
        }

        private IEnumerator coroutineJump()
        {
            if (PlayerPrefs.GetInt("_chooseAvatar") == 1)
            {
                _rbPlayer.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
                _playerAvatar.sprite = _blueBirdImageDown;
                yield return new WaitForSeconds(0.2f);
                _playerAvatar.sprite = _blueBirdImage;
            }

            if (PlayerPrefs.GetInt("_chooseAvatar") == 2)
            {
                _rbPlayer.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
                _playerAvatar.sprite = _pinkBirdImageDown;
                yield return new WaitForSeconds(0.2f);
                _playerAvatar.sprite = _pinkBirdImage;
            }
        }
    }
}
