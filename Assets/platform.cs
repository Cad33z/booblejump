using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public AudioSource jumpSound;
    public float force = 10.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           jumpSound.Play();
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 platformNormal = collision.GetContact(0).normal;

            // Задаем скорость отталкивания по оси y
            float velocityY = 10f;
            playerRigidbody.velocity = new Vector2(-platformNormal.x * 10f, velocityY);
        }
    }





    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
