using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

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

        private GameObject _buttonJump, BackToMainMenu;

        private int _valueFruits;
        private float m_XAxis, m_YAxis;

        private void Awake()
        {
            _buttonJump = GameObject.Find("Jump");
            BackToMainMenu = GameObject.Find("Back to Main Menu");
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            m_XAxis = 900f;
            m_YAxis = -600f;

            IEventAssistant._onSetDamage += LoseLevel;
            IEventAssistant._onSetFruits += GetFruits;
            IEventAssistant._onSetHoldOut += WinLevel;

#if UNITY_EDITOR
            _buttonJump.SetActive(false);
#elif UNITY_WEBGL
            _buttonJump.SetActive(false);
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            _buttonJump.SetActive(false);
#elif UNITY_ANDROID
            _buttonJump.SetActive(true);
#endif
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
            _buttonJump.SetActive(false);
            BackToMainMenu.SetActive(false);
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
            _buttonJump.SetActive(false);
            BackToMainMenu.SetActive(false);

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
