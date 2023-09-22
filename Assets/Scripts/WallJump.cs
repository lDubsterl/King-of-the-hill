using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpMove : BasicMoveScript
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    QualitySettings.vSyncCount = 0;
    //    Application.targetFrameRate = 60;
    //    body = GetComponent<Rigidbody2D>();
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        SurfaceCheck(Vector2.down, yRayDistance, out isGround, ground);
        SurfaceCheck(Vector2.right, xRayDistance, out isWall, wall);
        SurfaceCheck(Vector2.left, xRayDistance, out isWall, wall);
        Jump();
        Walljump();
        FallAcceleration(true);
        if (!blockX)
            Walk();
    }

    void Walljump()
    {
        if (isWall && !isGround)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(Vector2.right * jumpForce);
                blockX = true;
            }
        else
            blockX = false;
    }
}
