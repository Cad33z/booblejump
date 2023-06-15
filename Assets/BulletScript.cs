using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float searchRadius; // ������ ������ �������� enemy
    public LayerMask enemyLayer; // ����� ���� enemy
    public float bulletSpeed; // �������� ����
    public float destroyTime; // ����� ����������� ���� ����� ��������

    private bool foundEnemy = false; // ����, �����������, ��� �� ������ ����
    public Rigidbody2D bulletRB;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        if (!foundEnemy)
        {
            // ������� ���� �����
            bulletRB.velocity = transform.up * bulletSpeed;
        }
        else
        {
            // ���� ��� ����� �����, �� ������� ��
            bulletRB.velocity = Vector2.zero;
        }

        SearchForEnemies();
    }

    void SearchForEnemies()
    {
        // ���� ��� ���������� � ������� � � ������ ���� enemy
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, enemyLayer);

        // ���� ������ ���� �� ���� ��������� �����
        if (colliders.Length > 0)
        {
            foundEnemy = true;

            // ������� ���������� �����
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = collider.gameObject;
                    closestDistance = distance;
                }
            }

            // ���������� ���� � ������� �����
            if (closestEnemy != null)
            {
                Vector2 direction = closestEnemy.transform.position - transform.position;
                bulletRB.velocity = direction.normalized * bulletSpeed;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
