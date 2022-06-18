using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject gameStart;
    public GameObject menu;
    public GameObject menu2;
    public void StartGame()
    {
        menu.SetActive(false);
        gameStart.SetActive(true);
    }

    public void ShowDirections()
    {
        menu2.SetActive(true);
        menu.SetActive(false);
    }

    public void DirectionsReturn()
    {
        menu2.SetActive(false);
        menu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
