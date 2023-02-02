using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TreeEnemyController : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;

    public Animator animator;
    public GameObject deathEffect;

    public AIPath aiPath;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        DefenderController defender = collision.GetComponent<DefenderController>();
        if (defender != null)
        {
            StartCoroutine(defender.TakeDamage(damage));
        }

        TargetController target = collision.GetComponent<TargetController>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (aiPath.desiredVelocity.x > 0f)
        {
            animator.SetTrigger("Right");
        }
        if (aiPath.desiredVelocity.x < 0f)
        {
            animator.SetTrigger("Left");
        }
        if (aiPath.desiredVelocity.y > 0.5f)
        {
            animator.SetTrigger("Up");
        }
        if (aiPath.desiredVelocity.y < -0.5f)
        {
            animator.SetTrigger("Down");
        }
    }
}