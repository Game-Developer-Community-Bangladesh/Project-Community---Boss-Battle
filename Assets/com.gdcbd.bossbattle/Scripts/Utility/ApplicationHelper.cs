using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace com.gdcbd.bossbattle.utility
{
    public class ApplicationHelper : MonoBehaviour
    {
        [SerializeField] public UnityEvent _startGame;
        [SerializeField] private float _loadAfter = 3f;
        void Start()
        {
            DOVirtual.DelayedCall(_loadAfter, () => _startGame.Invoke());
        }

        public void ReloadCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        public void QuitGame()
        {
          Application.Quit();
        }
    }
}