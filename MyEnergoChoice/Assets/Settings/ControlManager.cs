using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControlManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    public void GoToMenu()
    {
        audioSource.Play();
        StartCoroutine(Menu());
        
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Settings");
    }
}
