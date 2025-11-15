using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Popups
{
    public class ExitPopup : MonoBehaviour
    {
        
        [SerializeField] private Button _trueExitButton;
        [SerializeField] private Button _falseExitButton;

        private void Awake()
        {
            _trueExitButton.onClick.AddListener(TrueExit);
            _falseExitButton.onClick.AddListener(FalseExit);
        }

        private void TrueExit()
        {
            Application.Quit();
        }

        private void FalseExit()
        {
            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            _trueExitButton.onClick.RemoveListener(TrueExit);
            _falseExitButton.onClick.RemoveListener(FalseExit);
        }
    }
}
