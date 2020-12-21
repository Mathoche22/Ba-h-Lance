using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }

    public void BackButton()
    {
        Debug.Log("Quitting...");
        Application.Quit();

    }
}