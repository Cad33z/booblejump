using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float searchRadius; // Радиус поиска объектов enemy
    public LayerMask enemyLayer; // Маска слоя enemy
    public float bulletSpeed; // Скорость пули
    public float destroyTime; // Время уничтожения пули после создания

    private bool foundEnemy = false; // Флаг, указывающий, был ли найден враг
    public Rigidbody2D bulletRB;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        if (!foundEnemy)
        {
            // Двигаем пулю вверх
            bulletRB.velocity = transform.up * bulletSpeed;
        }
        else
        {
            // Пуля уже нашла врага, не двигаем ее
            bulletRB.velocity = Vector2.zero;
        }

        SearchForEnemies();
    }

    void SearchForEnemies()
    {
        // Ищем все коллайдеры в радиусе и с маской слоя enemy
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, enemyLayer);

        // Если найден хотя бы один коллайдер врага
        if (colliders.Length > 0)
        {
            foundEnemy = true;

            // Находим ближайшего врага
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

            // Направляем пулю в сторону врага
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
