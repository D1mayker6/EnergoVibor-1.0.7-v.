
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BetCheck : MonoBehaviour
{
    [SerializeField] private Button BetCheckButton;
    [SerializeField] private Button BetButtonPlus;
    [SerializeField] private Button BetButtonMinus;
    [SerializeField] private Text BetValue;
    [SerializeField] private Text BalanceBet;
    [SerializeField] private Canvas BetCanvas;
    private AudioSource audiosource;
    [SerializeField] private AudioClip cardDrop;
    [SerializeField] private Text MessageText;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = GameData.SFXVolume;
    }
    private void Update()
    {
        BetValue.text = Convert.ToString( GameData.EnergiksBet);
        BalanceBet.text = "Баланс: " + Convert.ToString(GameData.Energiks[GameData.currentPlayer]);
    }
    public void BetCheckButtton()
    {
        if (GameData.EnergiksBet <= GameData.Energiks[GameData.currentPlayer])
        {
            audiosource.Play();
            BetCanvas.GetComponent<Animator>().SetTrigger("BetEnd");
            StartCoroutine("BetPanelEnd"); 
        }
        else
        {
            MessageText.text = "Недостаточно";
        }
    }
    public void ButtonBetPlus()
    {
        audiosource.Play();
        if(GameData.EnergiksBet<99)
        GameData.EnergiksBet++;
    }
    public void ButtonBetMinus()
    {
        audiosource.Play();
        if (GameData.EnergiksBet>1)
        GameData.EnergiksBet--;
    }

    private IEnumerator BetPanelEnd()
    {
        yield return new WaitForSeconds(1);
        audiosource.clip = cardDrop;
        audiosource.Play();
        BetCanvas.enabled = false;
    }
    public void MaxBet()
    {
        audiosource.Play();
        GameData.EnergiksBet = GameData.Energiks[GameData.currentPlayer];
    }
}
