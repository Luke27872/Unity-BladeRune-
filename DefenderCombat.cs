using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCombat : MonoBehaviour
{
    public Animator animator;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public Transform firePoint;
    public GameObject arrowPrefab;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            /*if (Input.GetKeyDown(KeyCode.O))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }*/
            if (Input.GetKeyDown(KeyCode.P))
            {
                Bow();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    void Bow()
    {
        animator.SetTrigger("Bow");
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}