using UnityEngine;
using UnityEngine.UI;

public class RecordsScr : MonoBehaviour
{
    public Text HighscoreText;
    public GameObject recordsMenu;

    public void Update()
    {
        HighscoreText = recordsMenu.GetComponentInChildren<Text>();
        HighscoreText.text = "Рекорд: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Highscore"));
    }
    public void RecordReset()
    {
        PlayerPrefs.SetFloat("Highscore", 0);
        PlayerPrefs.Save();
    }
    public void RecordsMenuExit()
    {
        recordsMenu.SetActive(false);
    }
}
