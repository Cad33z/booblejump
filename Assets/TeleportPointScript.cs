using UnityEngine;

public class TeleportPointScript : MonoBehaviour
{
    [SerializeField] private GameObject doodlik;
    [SerializeField] private GameObject opposition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Teleportation();
        }
    }

    private void Teleportation()
    {
        Vector2 newPosition = new Vector2(opposition.transform.position.x, doodlik.transform.position.y);
        doodlik.transform.position = newPosition;
    }
}
