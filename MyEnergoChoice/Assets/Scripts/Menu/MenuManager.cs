using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private Canvas _exitPopupPrefab;
        [SerializeField] private Canvas _playerCountCanvasPrefab;

        private void Awake()
        {
            _playButton.onClick.AddListener(Play);
            _settingsButton.onClick.AddListener(Settings);
            _infoButton.onClick.AddListener(Info);
            _exitButton.onClick.AddListener(ExitGame);
        }
        private void Start()
        {
            Screen.SetResolution(1920, 1080, true);
        }

        private void ExitGame()
        {
            Instantiate(_exitPopupPrefab);
        }
        public void Play()
        {
            Instantiate(_playerCountCanvasPrefab);
        }
        public void Info()
        {
            /*_buttons[2].GetComponent<AudioSource>().Play();
            _buttons[2].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            StartCoroutine(GoToInfo());*/
        }
        public void Settings()
        {
            /*_buttons[1].GetComponent<AudioSource>().Play();
            _buttons[1].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            StartCoroutine(GoToSettings());*/
        }
        /*IEnumerator GoToSettings()
        {*/
            /*yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("Settings");*/
        /*}*/
        /*IEnumerator GoToInfo()
        {*/
            /*yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("GameInfo");*/
        /*}*/

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(Play);
            _settingsButton.onClick.RemoveListener(Settings);
            _infoButton.onClick.RemoveListener(Info);
            _exitButton.onClick.RemoveListener(ExitGame);
        }
    }
}
