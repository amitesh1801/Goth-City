using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private CapsuleCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;
    private float dirx = 0f;
    [SerializeField] private float runspeed = 7f;
    [SerializeField] private float jumpforce = 10f;
    private enum MovementState { idle, walking, jumping, falling };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirx * runspeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirx > 0f)
        {
            state = MovementState.walking;
            transform.localScale = Vector3.one;
        }
        else if (dirx < 0f)
        {
            state = MovementState.walking;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.4f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
