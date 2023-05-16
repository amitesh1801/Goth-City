using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;
    private Transform currentPoint;
    

    [SerializeField] private float speed;
    
    private Animator anim;

    private void Awake()
    {
        
        anim = GetComponent<Animator>();
        currentPoint = rightEdge.transform;
        anim.SetBool("running", true);
    }
    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        float movementSpeed = speed * Time.deltaTime;
        if (currentPoint == rightEdge.transform)
            enemy.Translate(movementSpeed, 0,0);
        else
        {
            enemy.Translate(-movementSpeed, 0, 0);
        }
        if(Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == rightEdge.transform)
        {
            flip();
            currentPoint = leftEdge.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftEdge.transform)
        {
            flip();
            currentPoint = rightEdge.transform;
        }
    }
    private void flip()
    {
        Vector3 localScale = enemy.localScale;
        localScale.x *= -1;
        enemy.localScale = localScale;
    }
}
