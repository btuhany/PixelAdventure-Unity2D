using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : SingletonObject<GameManager>
    {
        public event System.Action OnGameEnd;
        public void EndGame()
        {
            Time.timeScale = 0f;
            OnGameEnd?.Invoke();
        }
        private void Awake()
        {
            SingletonThisObject(this);
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
        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        }
    }
}

