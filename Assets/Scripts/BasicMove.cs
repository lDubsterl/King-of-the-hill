using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveScript : MonoBehaviour
{
    public Rigidbody2D body;

    private Vector2 moveVector;

    public float speed = 8f;

    public float jumpForce = 700f;

    protected bool isGround;

    protected bool isWall;

    public float xRayDistance = 0.55f;

    public float yRayDistance = 0.62f;

    public LayerMask ground;

    public LayerMask wall;

    private RaycastHit2D hit;

    protected float gravityScale;

    protected float gravityScaleLimit;

    protected float slideGravity;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        body = GetComponent<Rigidbody2D>();
        gravityScale = body.gravityScale;
        gravityScaleLimit = gravityScale * 200;
        slideGravity = gravityScale / 2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SurfaceCheck(Vector2.down, yRayDistance, out isGround, ground);
        SurfaceCheck(Vector2.right, xRayDistance, out isWall, wall);
        SurfaceCheck(Vector2.left, xRayDistance, out isWall, wall);
        Walldrop();
        Jump();
        FallAcceleration(false);
        if (!blockX)
            Walk();
    }

    protected void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveVector.x * speed, body.velocity.y);
    }

    protected bool blockX;

    void Walldrop()
    {
        if (isWall && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            blockX = true;
        }
        else
        {
            blockX = false;
        }
    }

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            if (isGround)
                body.AddForce(Vector2.up * jumpForce);
    }

    protected void SurfaceCheck(Vector2 direction, float rayDistance, out bool isSurface, LayerMask surface)
    {
        hit = Physics2D.Raycast(body.position, direction, rayDistance, surface);
        Ray2D ray = new Ray2D(body.position, direction);
        Debug.DrawLine(body.position, ray.GetPoint(rayDistance), Color.blue);
        if (hit.collider != null)
            isSurface = true;
        else
            isSurface = false;
    }
    protected void FallAcceleration(bool WallSlide)
    {
        if (WallSlide && isWall && body.velocity.y < 0.002 && Input.GetKey(KeyCode.LeftArrow))
            body.gravityScale = slideGravity;
        else
            body.gravityScale = !isGround ? Mathf.Lerp(gravityScale, gravityScaleLimit, Time.deltaTime) : gravityScale;
    }
}
