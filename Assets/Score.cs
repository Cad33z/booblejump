using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    [SerializeField]
    public float score = 0;
    [SerializeField]
    private doodle doodlik;
    private Text scoreText;

    public Text recordText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doodlik.gameObject.transform.position.y > score)
        {
            score = doodlik.gameObject.transform.position.y;
            scoreText.text = "—чет: " + Mathf.RoundToInt(score);
        }
        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
         recordText.text = "–екорд: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Highscore"));
    }
}
