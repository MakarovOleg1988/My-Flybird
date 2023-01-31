using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFlyBird
{
    public class FinishGame : MonoBehaviour
    {
        FinalScore _finalScore = new FinalScore();

        [SerializeField] public GameObject _LoseMenu;
        [SerializeField] private bool _timerstop;

        public bool Timerstop
        {
            get { return _timerstop; }
            set { _timerstop = value; }
        }

        private void Start()
        {
            IEventAssistant._onSetDamage += EndGame;
        }

        private void EndGame()
        {
            StartCoroutine(CoroutineFinishGame());
            _finalScore.Timerstop = true;
        }

        private IEnumerator CoroutineFinishGame()
        {
            _LoseMenu.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Main Menu");
        }

        private void OnDestroy()
        {
            IEventAssistant._onSetDamage -= EndGame;
        }
    }

    public class FinalScore
    {
        private bool _timerstop;

        public bool Timerstop
        {
            get
            { return _timerstop; }
            set
            { _timerstop = value; }
        }
    }
}
