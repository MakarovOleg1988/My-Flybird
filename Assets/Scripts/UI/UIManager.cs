using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace MyFlyBird
{
    public class UIManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] 
        private GameObject _mainMenu;
        
        [SerializeField] 
        private GameObject _menuChooseDifficulty;
        
        [SerializeField] 
        private GameObject _menuChoosePerson;

        [SerializeField]
        private GameObject _menuOptions;

        public void ChoosePerson()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineChoosePerson());
        }

        private IEnumerator CoroutineChoosePerson()
        {
            yield return new WaitForSeconds(0.2f);
            _mainMenu.SetActive(false);
            _menuChoosePerson.SetActive(true);
        }

        public void TransitionToOptions()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineTransitionToOptions());
        }

        private IEnumerator CoroutineTransitionToOptions()
        {
            yield return new WaitForSeconds(0.2f);
            _mainMenu.SetActive(false);
            _menuOptions.SetActive(true);
        }

        public void StartLevel(int level)
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineStartLevel1(level));
        }

        private IEnumerator CoroutineStartLevel1(int level)
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(level);
        }

        public IEnumerator CoroutineStartLevel3(int level)
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(level);
        }

        public void BackToMainMenu()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineBackToMainMenu());
        }

        private IEnumerator CoroutineBackToMainMenu()
        {
            yield return new WaitForSeconds(0.2f);
            _mainMenu.SetActive(true);
            _menuChoosePerson.SetActive(false);
            _menuOptions.SetActive(false);
            _menuChooseDifficulty.SetActive(false);
        }

        public void SetNextLevel()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineSetNextLevel());
        }

        private IEnumerator CoroutineSetNextLevel()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitLevel()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineQuitLevel());
        }

        private IEnumerator CoroutineQuitLevel()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Main Menu");
        }

        public void QuitGame()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineQuitGame());
        }

        private IEnumerator CoroutineQuitGame()
        {
            yield return new WaitForSeconds(0.2f);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.Quit();
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#elif UNITY_ANDROID
            Application.Quit();
#endif
        }

        public void ChooseBlueBird()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineChooseBlueBird());
        }

        private IEnumerator CoroutineChooseBlueBird()
        {
            yield return new WaitForSeconds(0.2f);
            PlayerPrefs.SetInt("_chooseAvatar", 1);
            PlayerPrefs.Save();
            _menuChoosePerson.SetActive(false);
            _menuChooseDifficulty.SetActive(true);
        }

        public void ChoosePinkBird()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineChoosePinkBird());
        }

        private IEnumerator CoroutineChoosePinkBird()
        {
            yield return new WaitForSeconds(0.2f);
            PlayerPrefs.SetInt("_chooseAvatar", 2);
            PlayerPrefs.Save();
            _menuChoosePerson.SetActive(false);
            _menuChooseDifficulty.SetActive(true);
        }
    }
}
