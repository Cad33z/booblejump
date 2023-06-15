using Mono.Cecil.Cil;
using UnityEngine;

public class breakableplatform : MonoBehaviour
{
    public Animator doodlePlatformAnimator; // Ссылка на компонент анимации платформы
    public AudioSource breakingSound; // Ссылка на компонент проигрывания звука разлома
    private bool playerCollisionOccurred = false; // Флаг, указывающий, было ли столкновение с игроком
    public Collider2D platformCollider;
    public GameObject BrokenPlatformPrefab;
    public Sprite breakedSprite;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0 && collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(platformCollider, collision.collider);
            if (!playerCollisionOccurred)
            {
                breakingSound.Play();
                doodlePlatformAnimator.SetTrigger("Break");
                playerCollisionOccurred = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            playerCollisionOccurred = false;
            Vector3 spawnerPosition = new Vector3();
            spawnerPosition.x = Random.Range(-1.9f, 1.9f);
            spawnerPosition.y = Random.Range(transform.position.y + 15f, transform.position.y + 16f);
            doodlePlatformAnimator.SetTrigger("reset");

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
                    if (collider.CompareTag("BrokenPlatform"))
                    {
                        overlapDetected = true;
                        break;
                    }
                }

                if (overlapDetected)
                {
                    spawnerPosition.y += platformDistance;
                }
            } while (overlapDetected);

            GameObject newBrokenPlatform = Instantiate(BrokenPlatformPrefab, spawnerPosition, Quaternion.identity);

            Destroy(gameObject);
        }
    }

}
