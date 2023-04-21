using UnityEngine;

namespace MyFlyBird
{
    public class PlayerParam : MonoBehaviour
    {
        protected NewControls _controls;
        protected Rigidbody2D _rbPlayer;

        protected SpriteRenderer _playerAvatar;

        [SerializeField] 
        protected Sprite _blueBirdImage;
        
        [SerializeField] 
        protected Sprite _pinkBirdImage;

        [SerializeField] 
        protected Sprite _blueBirdImageDown;
        
        [SerializeField] 
        protected Sprite _pinkBirdImageDown;

        [Space, SerializeField, Range(1f, 20f)] 
        protected float _jumpForce;
    }
}
