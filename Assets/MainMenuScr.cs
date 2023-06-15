using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

public class MainMenuScr : MonoBehaviour
{

    public GameObject recordsMenu;

    private void Start()
    {
        recordsMenu.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameExit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }


    public void RecordsMenu()
    {
        recordsMenu.SetActive(true);
    }


}
