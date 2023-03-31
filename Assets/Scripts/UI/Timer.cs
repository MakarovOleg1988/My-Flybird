using UnityEngine;
using UnityEngine.UI;

namespace MyFlyBird
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _startTime = 180f;
        private float m_XAxis, m_YAxis;

        [Space, SerializeField] private RectTransform _rectTransformTimer;
        [SerializeField] public Text _timer;

        private void Start()
        {
            _timer.text = _startTime.ToString("F1");
            m_XAxis = 0.5f;
            m_YAxis = 0.5f;
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
                _rectTransformTimer.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
                IEventAssistant.SendHoldOut();
            }
        }
    }
}
