using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public GameObject defender;

    public Vector2 movement;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    public GameController gameController;

    public Transform firePoint;

    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    public TargetController targetController;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x == 1)
        {
            firePoint.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (movement.x == -1)
        {
            firePoint.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (movement.y == 1)
        {
            firePoint.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.y == -1)
        {
            firePoint.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (movement.x == 0 && movement.y == 0)
        {
            firePoint.localEulerAngles = new Vector3(0, 0, 0);
        }

        healthBar.SetHealth((int)currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator TakeDamage(int damage)
    {
        sprite.color = new Color(255, 0, 0, 255);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(255, 255, 255, 255);
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameController.respawn = true;
        defender.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aura")
        {
            gameController.healthDrain = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aura")
        {
            gameController.healthDrain = true;
        }
    }
}