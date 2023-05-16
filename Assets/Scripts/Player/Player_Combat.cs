using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform kickPoint;

    [SerializeField] private int attackDamage = 20;
    [SerializeField] private float attackRange = 0.5f;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Punch();
                nextAttackTime = Time.time + 1 / attackRate;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Kick();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
    }

        private void Punch()
        {
            anim.SetTrigger("punch");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }

        private void Kick()
        {
            anim.SetTrigger("kick");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
                enemy.GetComponent<Health>().TakeDamage(attackDamage);                
        }
        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    } 
