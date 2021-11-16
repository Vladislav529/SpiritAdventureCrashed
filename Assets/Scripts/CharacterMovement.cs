using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Set in Inspector")]
    public float speed = 5f;
    public float jumpForce = 500f;
    
    
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    void FixedUpdate()
    {
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal"); // получаем a d;

        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(xAxis * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (xAxis > 0 && !facingRight)
            Flip();
        else if (xAxis < 0 && facingRight)
            Flip();

    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
