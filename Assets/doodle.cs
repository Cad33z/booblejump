using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doodle : MonoBehaviour
{
    float horiz;
    public Rigidbody2D DoodleBody;
    private float moveInput;
    private float speed = 10f;
    public GameObject bulletPrefab; // Префаб пули
    private bool isShooting = false; // Флаг, указывающий, происходит ли выстрел?


    void Start()
    {
        DoodleBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Счет
        if (gameObject.transform.position.y > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", gameObject.transform.position.y);
            PlayerPrefs.Save();
        }


        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            moveInput = Input.GetAxis("Horizontal");
            DoodleBody.velocity = new Vector2(moveInput * speed, DoodleBody.velocity.y);
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            horiz = Input.acceleration.x;
            horiz = Mathf.Clamp(horiz, -1f, 1f); // Ограничение значения horiz от -1 до 1
            DoodleBody.velocity = new Vector2(horiz * speed, DoodleBody.velocity.y);
        }

        if (Input.acceleration.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.acceleration.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isShooting)
            {
                // Создаем пулю
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                isShooting = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isShooting = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
