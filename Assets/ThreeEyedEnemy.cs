using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThreeEyedEnemy : MonoBehaviour
{
    public AudioSource enemySound;
    public BoxCollider2D enemyCollider;
    public Animator ThreeEyedEnemyAnimator;
    public bool killed;


    // Start is called before the first frame update
    void Start()
    {
        enemySound.Play();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !killed)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            Physics2D.IgnoreCollision(enemyCollider, collision.collider);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            ThreeEyedEnemyAnimator.SetTrigger("Dead");
            killed = true;
            enemySound.Stop();
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Vector3 spawnerPosition = new Vector3();
            spawnerPosition.x = Random.Range(-1.7f, 1.7f);
            spawnerPosition.y = Random.Range(transform.position.y + 27f, transform.position.y + 28f);
            GameObject newBrokenPlatform = Instantiate(gameObject, spawnerPosition, Quaternion.identity);
            killed = false;
            enemySound.Play();
            Destroy (gameObject);
        }
    }
}
