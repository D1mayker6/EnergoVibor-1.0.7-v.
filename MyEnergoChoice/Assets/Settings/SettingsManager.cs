using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Toggle FullScreen;
    [SerializeField] private Dropdown ScreenSize;
    [SerializeField] private Text ScreenSizeText;
    private Vector2Int[] resolutions = new Vector2Int[]
{
        new Vector2Int(1920, 1080),
        new Vector2Int(1600, 900),
        new Vector2Int(1440, 864),
        new Vector2Int(1366, 768),
        new Vector2Int(1280, 720),
};
    void Start()
    {
        ScreenSize.value=GameData.DropDownValue;
        ScreenSizeText.text = GameData.SizeLabel;
        FullScreen.isOn = true;
        SFXSlider.value = GameData.SFXVolume;
        MusicSlider.value = GameData.MusicVolume;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameData.SFXVolume;
        ScreenSize.onValueChanged.AddListener(ChangeResolution);
        FullScreen.isOn = GameData.ToggleisOn;
        

    }
    public void ChangeResolution(int index)
    {
        audioSource.Play();
        Screen.SetResolution(resolutions[index].x, resolutions[index].y, Screen.fullScreen);
        GameData.SizeLabel = resolutions[index].x.ToString() + "x" + resolutions[index].y.ToString();
        ScreenSizeText.text = GameData.SizeLabel;
        GameData.DropDownValue = index;
    }
    void Update()
    {
        GameData.MusicVolume=MusicSlider.value;
        GameData.SFXVolume=SFXSlider.value;
    }
    public void GoToMenu()
    {
        audioSource.Play();
        StartCoroutine(Menu());
    }
    IEnumerator Menu()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
    public void ToggleFullScreen ()
    {
        if (FullScreen.isOn)
        {
            GameData.ToggleisOn = true;
            audioSource.Play();
            Screen.fullScreen = true;
        }
        else 
        {
            GameData.ToggleisOn=false;
            audioSource.Play();
            Screen.fullScreen = false;
        }
    }
public void GoToControl()
    {
        audioSource.Play();
        StartCoroutine(Control());
    }
    IEnumerator Control()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Control"); 
    }
}
