using UnityEngine;
using UnityEngine.UI;

namespace MyFlyBird
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _startTime = 0f;
        [Space, SerializeField] public Text _timer;

        FinalScore _finalScore = new FinalScore();

        private void Start()
        {
            _timer.text = _startTime.ToString("F1");
        }

        private void Update()
        {
            if (_finalScore.Timerstop == false)
                _startTime += Time.deltaTime;

            _timer.text = _startTime.ToString("F1");
        }
    }
}
