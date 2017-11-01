using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public int damage;
    public float moveSpeed;
    public AudioClip hitSound;

    private Vector2 direction;

    void FixedUpdate()
    {
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void OffsetBullet(float offset)
    {
        transform.Translate(direction * offset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHP = collision.GetComponent<Health>();
            if (playerHP)
            {
                playerHP.TakeDamage(damage);
                SoundManager.PlaySound(hitSound);
            }
        }
        if (!collision.CompareTag("Bullet") && !collision.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
