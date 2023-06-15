using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public AudioSource enemySound;
    public BoxCollider2D enemyCollider;
   

    void Start()
    {
        enemySound.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene("GameOverScene");

        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
       
            
            Vector3 spawnerPosition = new Vector3();
            spawnerPosition.x = Random.Range(-1.7f, 1.7f);
            spawnerPosition.y = Random.Range(transform.position.y + 20f, transform.position.y + 21f);
            GameObject newBrokenPlatform = Instantiate(gameObject, spawnerPosition, Quaternion.identity);
            Destroy(gameObject);

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
            Destroy (gameObject);
        }
    }
}
