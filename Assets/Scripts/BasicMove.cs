using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveScript : MonoBehaviour
{
    public Rigidbody2D body;

    public Vector2 moveVector;

    public float speed = 8f;

    public float jumpForce = 350f;

    private bool isGround;

    public float yRayDistance = 0.3f;

    public LayerMask ground;

    private bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        float test = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck();
        jump();
        walk();
        fallAcceleration();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveVector.x * speed, body.velocity.y);
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || jumpPressed)
        {
            jumpPressed = true;
            if (isGround)
            {
                body.AddForce(Vector2.up * jumpForce);
                jumpPressed = false;
            }
        }
    }

    void groundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(body.position, Vector2.down, yRayDistance, ground);
        Vector2 rayEnd = body.position;
        rayEnd.y -= yRayDistance;
        Debug.DrawLine(body.position, rayEnd, Color.blue);
        if (hit.collider != null)
            isGround = true;
        else
            isGround = false;
    }

    void fallAcceleration()
    {
        if (!isGround)
            Physics2D.gravity = Vector2.Lerp(Physics2D.gravity, new Vector2(0, -90f), Time.deltaTime);
        else
            Physics2D.gravity = new Vector2(0, -9.81f);
    }
}
