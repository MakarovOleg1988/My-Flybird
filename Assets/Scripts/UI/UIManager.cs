using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFlyBird
{
    public class UIManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _menuChooseDifficulty;
        [SerializeField] private GameObject _menuChoosePerson;
        private int _chooseAvatar;

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

        public void StartLevel1()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineStartLevel1());
        }

        private IEnumerator CoroutineStartLevel1()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 1");
        }

        public void StartLevel2()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineStartLevel2());
        }

        private IEnumerator CoroutineStartLevel2()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 2");
        }

        public void StartLevel3()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineStartLevel3());
        }

        private IEnumerator CoroutineStartLevel3()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 3");
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
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
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
