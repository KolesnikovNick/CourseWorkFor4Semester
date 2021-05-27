using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLinks : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;
    public AudioSource fireSound;
    
    public void NewGame(){
        StartCoroutine(NewGameStart());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator NewGameStart(){
        fadeOut.SetActive(true);
        fireSound.Stop();
        buttonClick.Play();
        yield return new WaitForSeconds(6);
        loadText.SetActive(true);
        SceneManager.LoadScene(1);
    }
}
