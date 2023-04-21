using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace MyFlyBird
{
    public class SetRulesGame : MonoBehaviour, IEventAssistant
    {
        [SerializeField] 
        private GameObject _winMenu;
        
        [SerializeField] 
        private GameObject _loseMenu;
        
        [HideInInspector] 
        public GameObject _player;
        
        [SerializeField] 
        private TextMeshProUGUI _textFruits;

        [SerializeField]
        private RectTransform _rectTransformFruits;

        private int _valueFruits;
        private float m_XAxis, m_YAxis;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            m_XAxis = 900f;
            m_YAxis = -600f;

            IEventAssistant._onSetDamage += LoseLevel;
            IEventAssistant._onSetFruits += GetFruits;
            IEventAssistant._onSetHoldOut += WinLevel;
        }

        private void GetFruits()
        {
            StartCoroutine(CoroutineGetFruits());
        }

        private IEnumerator CoroutineGetFruits()
        {
            _valueFruits++;
            _textFruits.text = _valueFruits.ToString();
            yield return new WaitForSeconds(2f);
        }

        private void WinLevel()
        {
            StartCoroutine(CoroutineWinLevel());
        }

        private IEnumerator CoroutineWinLevel()
        {
            _rectTransformFruits.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
            _winMenu.SetActive(true);
            _player.SetActive(false);
            yield return new WaitForSeconds(2f);
        }

        private void LoseLevel()
        {
            StartCoroutine(CoroutineLoseLevel());
        }

        private IEnumerator CoroutineLoseLevel()
        {
            _player.SetActive(false);
            _loseMenu.SetActive(true);

            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Main Menu");
        }

        private void OnDestroy()
        {
            IEventAssistant._onSetDamage -= LoseLevel;
            IEventAssistant._onSetHoldOut -= WinLevel;
            IEventAssistant._onSetFruits -= GetFruits;
        }
    }
}
