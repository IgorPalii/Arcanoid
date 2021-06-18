using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject menuPanel, gamePanel;
    void Start()
    {
        menuPanel = GameObject.Find("MenuPanel");
        gamePanel = GameObject.Find("GamePanel");
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0;                           
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void SwithcPause() 
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
        gamePanel.SetActive(!gamePanel.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
