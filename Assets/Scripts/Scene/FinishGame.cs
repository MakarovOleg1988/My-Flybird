using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFlyBird
{
    public class FinishGame : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private GameObject _loseMenu;
        [HideInInspector] public GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            IEventAssistant._onSetDamage += LoseLevel;
            IEventAssistant._onSetHoldOut += WinLevel;
        }

        private void WinLevel()
        {
            StartCoroutine(CoroutineWinLevel());
        }

        private IEnumerator CoroutineWinLevel()
        {
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
        }
    }
}
