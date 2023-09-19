using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Vector2 moveVector;
    public float speed = 8f;
    public float jumpForce = 350f;
    public bool isGround;
    public Transform groundHitbox;
    public float checkRadius = 0.5f;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        groundCheck();
        jump();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveVector.x * speed, body.velocity.y);

    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGround)
                body.AddForce(Vector2.up * jumpForce);
        }
    }

    void groundCheck()
    {
         isGround = Physics2D.OverlapCircle(groundHitbox.position, checkRadius, ground);
    }
}
