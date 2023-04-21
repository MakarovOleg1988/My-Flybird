using UnityEngine;
using TMPro;

namespace MyFlyBird
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] 
        private float _startTime = 180f;
        
        [SerializeField] 
        public TextMeshProUGUI _timer;

        private void Start()
        {
            _timer.text = _startTime.ToString("F1");
        }

        private void Update()
        {
            if (_startTime >= 0f)
            {
                _startTime -= Time.deltaTime;
                _timer.text = _startTime.ToString("F1");
            }
            else
            {
                IEventAssistant.SendHoldOut();
            }
        }
    }
}
