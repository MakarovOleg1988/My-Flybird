using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFlyBird
{
    public class UIManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _menuChooseDifficulty;
        private void Start()
        {
            IEventAssistant._onSetButton += QuitLevel;
            IEventAssistant._onSetButton += BackToMainMenu;
            IEventAssistant._onSetButton += ChooseDifficulty;
            IEventAssistant._onSetButton += StartLevel1;
            IEventAssistant._onSetButton += StartLevel2;
            IEventAssistant._onSetButton += StartLevel3;
            IEventAssistant._onSetButton += QuitGame;
        }

        public void ChooseDifficulty()
        {
            StartCoroutine(CoroutineChooseDifficulty());
        }

        private IEnumerator CoroutineChooseDifficulty()
        {
            yield return new WaitForSeconds(0.2f);
            _mainMenu.SetActive(false);
            _menuChooseDifficulty.SetActive(true);
        }

        public void StartLevel1()
        {
            StartCoroutine(CoroutineStartLevel1());
        }

        private IEnumerator CoroutineStartLevel1()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 1");
        }

        public void StartLevel2()
        {
            StartCoroutine(CoroutineStartLevel2());
        }

        private IEnumerator CoroutineStartLevel2()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 2");
        }

        public void StartLevel3()
        {
            StartCoroutine(CoroutineStartLevel3());
        }

        private IEnumerator CoroutineStartLevel3()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 3");
        }

        public void BackToMainMenu()
        {
            StartCoroutine(CoroutineBackToMainMenu());
        }

        private IEnumerator CoroutineBackToMainMenu()
        {
            yield return new WaitForSeconds(0.2f);
            _mainMenu.SetActive(true);
            _menuChooseDifficulty.SetActive(false);
        }

        public void QuitLevel()
        {
            StartCoroutine(CoroutineQuitLevel());
        }

        private IEnumerator CoroutineQuitLevel()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Main Menu");
        }

        public void QuitGame()
        {
            StartCoroutine(CoroutineQuitGame());
        }

        private IEnumerator CoroutineQuitGame()
        {
            yield return new WaitForSeconds(0.2f);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
        }
    }
}
