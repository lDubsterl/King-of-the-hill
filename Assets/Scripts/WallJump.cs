using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpMove : BasicMoveScript
{
    void FixedUpdate()
    {
        SurfaceCheck(Vector2.down, col.bounds.extents.y + 0.1f, out isGround, ground);
        SurfaceCheck(Vector2.right, col.bounds.extents.x + 0.1f, out isRightWall, wall);
        SurfaceCheck(Vector2.left, col.bounds.extents.x + 0.1f, out isLeftWall, wall);
        isWall = isRightWall || isLeftWall;
        Walljump();
        Jump();
        FallAcceleration(true);
        Walk();
    }

    public float blockDuration = 0.5f;

    private bool isLeftWall, isRightWall;

    private float blockTime = 0;
    void Walljump()
    {

        if (isWall)
        {
            SurfaceCheck(Vector2.down, col.bounds.extents.y + 0.5f, out isGround, ground);
            if (!isGround)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isLeftWall)
                    {
                        body.velocity = new Vector2(Mathf.Cos(Mathf.PI / 3), Mathf.Sin(Mathf.PI / 6));
                        body.AddForce(new Vector2(2 * Mathf.Cos(Mathf.PI / 3), 2 * Mathf.Sin(Mathf.PI / 6)) * jumpForce);
                    }
                    else
                    {
                        body.velocity = new Vector2(Mathf.Cos(Mathf.PI / 3) * -1, Mathf.Sin(Mathf.PI / 6));
                        body.AddForce(new Vector2(-2 * Mathf.Cos(Mathf.PI / 3), 2 * Mathf.Sin(Mathf.PI / 6)) * jumpForce);
                    }
                    
                    blockX = true;
                }
            SurfaceCheck(Vector2.down, col.bounds.extents.y + 0.1f, out isGround, ground);
        }
        if (blockX && (blockTime += Time.deltaTime) >= blockDuration)
            if (isWall || isGround || Input.GetAxisRaw("Horizontal") != 0)
            {
                blockX = false;
                blockTime = 0;
            }
    }
}
