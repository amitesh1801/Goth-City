using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    private float lifetime;
    [SerializeField] private float resettime;

    [SerializeField] private float speed;
    [SerializeField] protected float damage;

    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;
    void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > resettime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;

        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);

        if (anim != null)
            anim.SetTrigger("explode");
        else
            gameObject.SetActive(false);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
