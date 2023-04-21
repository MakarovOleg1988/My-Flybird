using UnityEngine;

namespace MyFlyBird
{
    public class ObstaclesParam : MonoBehaviour
    {
        [SerializeField] 
        protected GameObject[] _walls;
        
        [HideInInspector] 
        protected Transform _startPoint;
        
        [SerializeField] 
        protected float _timeBetweenShots;
        
        [SerializeField] 
        protected float _startTimeShoot;
        
        [SerializeField, Range(0f, 20f)] 
        protected float _timeBetweenBustForce;
        
        [SerializeField, Range(0.1f, 1f)] 
        protected float _bustSpeedSpawn;
    }
}
