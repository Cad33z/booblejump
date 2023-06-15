using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public AudioSource jumpSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.y <= 0)
            {
                Rigidbody2D rb1 = collision.collider.GetComponent<Rigidbody2D>();
                if (rb1 != null)
                {
                    jumpSound.Play();
                    Vector2 vel = rb1.velocity;
                    vel.y = 10f;
                    rb1.velocity = vel;

                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Vector3 spawnerPosition = new Vector3();
            spawnerPosition.x = Random.Range(-1.9f, 1.9f);
            spawnerPosition.y = Random.Range(transform.position.y + 14f, transform.position.y + 15f);
            // Определяем расстояние между платформами
            float platformDistance = 1.5f;

            Collider2D[] colliders;
            bool overlapDetected;

            do
            {
                overlapDetected = false;

                colliders = Physics2D.OverlapCircleAll(spawnerPosition, 1f);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("GreenPlatform"))
                    {
                        // Найдена другая платформа в радиусе, устанавливаем флаг перекрытия и выходим из цикла
                        overlapDetected = true;
                        break;
                    }
                }

                if (overlapDetected)
                {
                    // Перемещаем позицию спауна платформы на расстояние platformDistance
                    spawnerPosition.y += platformDistance;
                }
            } while (overlapDetected);

            GameObject newBrokenPlatform = Instantiate(gameObject, spawnerPosition, Quaternion.identity);

            Destroy(gameObject);
        }
    }

}
