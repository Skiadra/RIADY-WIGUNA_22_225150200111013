using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject gameplayTutorial;
    public AudioSource audioSource;
    public AudioSource clicked;
    public GameObject lore;


    void Start()
    {
        audioSource.Play();    
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Gameplay()
    {
        clicked.Play();
        gameplayTutorial.SetActive(true);
    }

    public void Back()
    {
        clicked.Play();
        gameplayTutorial.SetActive(false);
    }
    public void LoreActive()
    {
        clicked.Play();
        lore.SetActive(true);
    }

    public void Back2()
    {
        clicked.Play();
        lore.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
