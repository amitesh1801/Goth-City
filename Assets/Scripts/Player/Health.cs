using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
            anim.SetTrigger("hurt");
        else
        {
            if(!dead)
            {
                anim.SetTrigger("death");
                foreach (Behaviour component in components)
                    component.enabled = false;
            }
        }
    }
    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}
