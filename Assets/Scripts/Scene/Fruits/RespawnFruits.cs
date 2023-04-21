using UnityEngine;

namespace MyFlyBird
{
    public class RespawnFruits : MonoBehaviour
    {
        [SerializeField] 
        private GameObject[] _fruits;
       
        [HideInInspector] 
        public Transform _startPoint;
     
        [SerializeField] 
        private float _timeBetweenShots;
      
        [SerializeField] 
        private float _startTimeShoot;

        private void Start()
        {
            _startPoint = GetComponent<Transform>();
        }

        private void Update()
        {
            CreateFruits(_startPoint, _fruits);
        }

        private void CreateFruits(Transform _startPoint, GameObject[] _fruits)
        {
            if ((_timeBetweenShots) <= 0)
            {
                int chooseFruits = Random.Range(0, _fruits.Length - 1);
                GameObject fruit = Instantiate(_fruits[chooseFruits], _startPoint.position + new Vector3(0f, Random.Range(-2f, 2f), 0f), Quaternion.identity);
                fruit.transform.parent = transform;

                _timeBetweenShots = _startTimeShoot;
            }
            else _timeBetweenShots -= Time.deltaTime;
        }
    }
}
