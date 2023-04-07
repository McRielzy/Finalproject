using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movespeed = 0f;
    private Rigidbody2D rb;
    public float movedirection;
    public SpriteRenderer sprite;
    public Animator animator;
    private BoxCollider2D box;


    [SerializeField] private LayerMask jumponGround;
    private enum MovementState { idle, walk, jump}

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();    

    }


    // Update is called once per frame
    void Update()
    {
        movedirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movedirection * 5f,rb.velocity.y);


       
            
        
        if(Input.GetKeyDown("space") && onGround())
        {
         rb.velocity = new Vector3(rb.velocity.x, 7f);
        }


        updateAnimationState();


    }

    private void updateAnimationState()
    {

        MovementState state;

        if (movedirection > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (movedirection < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.jump;
        }

        animator.SetInteger("state", (int)state);
    }


    private bool onGround()
    {
       return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, jumponGround);
    }

}
