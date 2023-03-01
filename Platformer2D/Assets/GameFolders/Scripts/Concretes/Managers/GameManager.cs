using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : SingletonObject<GameManager>
    {
        public bool IsGamePaused;
        public event System.Action OnGameEnd;
        public event System.Action OnGamePaused;
        public event System.Action OnGameResumed;
        public void EndGame()
        {
            Time.timeScale = 0f;
            OnGameEnd?.Invoke();
        }
        public void PauseGame()
        {
            if (IsGamePaused) return;
            IsGamePaused = true;
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();

        }
        public void ResumeGame()
        {
            if (!IsGamePaused) return;
            IsGamePaused = false;
            Time.timeScale = 1f;
            OnGameResumed?.Invoke();

        }
        private void Awake()
        {
            SingletonThisObject(this);
        }
        public void LoadSceneFromIndex(int sceneIndex = 0)
        {
            StartCoroutine(LoadSceneFromIndexAsync(sceneIndex));
        }
        public void LoadScene(int sceneIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        private IEnumerator LoadSceneFromIndexAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        }
        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}

