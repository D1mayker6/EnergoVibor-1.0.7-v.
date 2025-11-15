using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Popups
{
    public class CountPlayerPopup : MonoBehaviour
    {
        private int _playerCount = 2;

        private int PlayerCount
        {
            get => _playerCount;
            set
            {
                if (value is > 6 or < 2)
                    return;
                _playerCount = value;
                OnCountChanged?.Invoke();
            }
        }

        private event Action OnCountChanged;
        
        [SerializeField] private Button _plusButton;
        [SerializeField] private Button _minusButton;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        
        [SerializeField] private Text _countText;

        private void Awake()
        {
            OnCountChanged += ChangeCountText;
            _plusButton.onClick.AddListener(PlusCount);
            _minusButton.onClick.AddListener(MinusCount);
            _cancelButton.onClick.AddListener(CancelButton);
            _confirmButton.onClick.AddListener(ConfirmButton);
            _countText.text = "2";
        }
        
        private void PlusCount()
        {
            PlayerCount++;
        }
        
        private void MinusCount()
        {
            PlayerCount--;
        }

        private void CancelButton()
        {
            Destroy(gameObject);
        }

        private void ConfirmButton()
        {
            Debug.Log("a");
        }

        private void ChangeCountText()
        {
            _countText.text = PlayerCount.ToString();
        }

        private void OnDestroy()
        {
            OnCountChanged -= ChangeCountText;
            _plusButton.onClick.AddListener(PlusCount);
            _minusButton.onClick.AddListener(MinusCount);
            _cancelButton.onClick.AddListener(CancelButton);
            _confirmButton.onClick.AddListener(ConfirmButton);
        }
    }
}
