using UnityEngine;
using UnityEngine.SceneManagement;

public class doodle : MonoBehaviour
{
    float horiz;
    public Rigidbody2D DoodleBody;
    //private float moveInput;
    //private float speed = 10f;
    public GameObject bulletPrefab; // ������ ����
    private bool isShooting = false; // ����, �����������, ���������� �� �������?
    private float touchStartTime; // ����� ������ �������
    public float fastTouchDuration = 0.2f; // ����������������� �������, ����� ��������� �������
    void Start()
    {
        DoodleBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        if (gameObject.transform.position.y > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", gameObject.transform.position.y);
            PlayerPrefs.Save();
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

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time; 
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                float touchDuration = Time.time - touchStartTime; 

                if (touchDuration < fastTouchDuration && !isShooting)
                {
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    isShooting = true;
                }
                else
                {
                    isShooting = false;
                }
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
