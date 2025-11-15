using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        /*[SerializeField] private Text _countText;*/
    
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private Canvas _exitPopupPrefab;
        [SerializeField] private Canvas _playerCountCanvasCanvas;

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

        private void Update()
        {
            /*_countText.text = Convert.ToString(GameData.playerCount);*/
        }

        private void ExitGame()
        {
            Instantiate(_exitPopupPrefab);
        }
        public void Play()
        {
            /*_buttons[0].GetComponent<AudioSource>().Play();
            _buttons[0].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            for (int i = 0; i < 4; i++)
            {
                _buttons[i].enabled=false;
            }
            _playerCountCanvas.enabled = true;*/
        }
        public void PlusCount()
        {
            /*if (GameData.playerCount < 6)
            {
                _buttons[7].GetComponent<AudioSource>().Play();
                _buttons[7].GetComponent<AudioSource>().volume = GameData.SFXVolume;
                GameData.playerCount++;
            }*/
        }
        public void MinusCount()
        {
            /*if (GameData.playerCount > 2)
            {
                _buttons[6].GetComponent<AudioSource>().Play();
                _buttons[6].GetComponent<AudioSource>().volume = GameData.SFXVolume;
                GameData.playerCount--;
            }*/
        }
        public void Skins()
        {
            /*_buttons[5].GetComponent<AudioSource>().Play();
            _buttons[5].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            StartCoroutine(GoToSkins());*/
        }
        /*IEnumerator GoToSkins()
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("SkinsOption");
        }*/
        public void ExitPlayMenu()
        {
            /*_buttons[4].GetComponent<AudioSource>().Play();
            _buttons[4].GetComponent<AudioSource>().volume = GameData.SFXVolume;
            _playerCountCanvas.enabled = false;
            for (int i = 0; i < 4; i++)
            {
                _buttons[i].enabled = true;
            }*/
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
