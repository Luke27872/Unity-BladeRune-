using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    public int damage = 100;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TreeEnemyController treeEnemy = collision.GetComponent<TreeEnemyController>();
        if (treeEnemy != null)
        {
            treeEnemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}