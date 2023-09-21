using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpMove : BasicMoveScript
{
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void walljump()
    {
        if (isWall)
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Physics2D.gravity = new Vector2(0, -4.905f);
                if (Input.GetKeyDown(KeyCode.Space))
                    body.AddForce(Vector2.up * (float)(jumpForce / 1.5));
            }
            else
                Physics2D.gravity = new Vector2(0, -9.81f);
    }
}
