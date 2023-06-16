using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }

}
