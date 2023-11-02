using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementState { idle, running, jumping, falling }
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x , jumpForce);
        }


        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if(dirX > 0f){
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }
        if(rb.velocity.y > .1f){
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int) state);
    }
    private bool IsGrounded()
    { 
        //cheking whether the box collided
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
