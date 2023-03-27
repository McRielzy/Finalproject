using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rb;
    public float movedirection;
    public SpriteRenderer sprite;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        movedirection = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movedirection));

        if (movedirection < 0)
        {
            sprite.flipX = true;
        }
        else if (movespeed > 0)
        {
            sprite.flipX = false;
        }

        rb.velocity = new Vector2(movedirection * movespeed, rb.velocity.y);
    }


}
