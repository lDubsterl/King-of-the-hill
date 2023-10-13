using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : PlayerStats
{
	protected Rigidbody2D body;

	protected Collider2D col;

	private Vector2 moveVector;

	public bool isGround;

	public LayerMask ground;

	public LayerMask wall;

	private RaycastHit2D hit;

	public bool isWalljumpEnabled;

	public float blockDuration = 0.25f;

	private bool isWall, isLeftWall, isRightWall;

	private float blockTime = 0;

	private float gravityScale;

	private float gravityScaleLimit;

	// Start is called before the first frame update
	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		col = GetComponent<Collider2D>();
		body = GetComponent<Rigidbody2D>();
		gravityScale = body.gravityScale;
		gravityScaleLimit = gravityScale * 250;
		jumpIteration = jumpIterationLimit;
	}
	// Update is called once per frame

	Vector2 leftSide, rightSide;
	void FixedUpdate()
	{
		leftSide = new Vector2(col.bounds.center.x - col.bounds.extents.x + 0.001f, col.bounds.center.y);
		rightSide = new Vector2(col.bounds.center.x + col.bounds.extents.x - 0.001f, col.bounds.center.y);
		if (!isWalljumpEnabled)
		{
			isGround = SurfaceCheck(Vector2.down, col.bounds.center, col.bounds.extents.y + 0.1f, out isGround, ground); /*||
			SurfaceCheck(Vector2.down, leftSide, col.bounds.extents.y + 0.1f, out isGround, ground) ||
			SurfaceCheck(Vector2.down, rightSide, col.bounds.extents.y + 0.1f, out isGround, ground);*/
			Walldrop();
			FallAcceleration(false);
		}
		else
		{
			isGround = SurfaceCheck(Vector2.down, col.bounds.center, col.bounds.extents.y + 0.1f, out isGround, ground); /*||
			SurfaceCheck(Vector2.down, leftSide, col.bounds.extents.y + 0.1f, out isGround, ground) ||
			SurfaceCheck(Vector2.down, rightSide, col.bounds.extents.y + 0.1f, out isGround, ground);*/
			isWall = SurfaceCheck(Vector2.right, col.bounds.center, col.bounds.extents.x + 0.1f, out isWall, wall) ||
			SurfaceCheck(Vector2.left, col.bounds.center, col.bounds.extents.x + 0.1f, out isWall, wall);
			Walljump();
			FallAcceleration(true);
		}
		Jump();
		Walk();
	}

	protected void Walk()
	{
		if (!blockX)
		{
			moveVector.x = Input.GetAxis("Horizontal");
			body.velocity = new Vector2(moveVector.x * speed, body.velocity.y);
		}
	}


	private bool jumpControl;
	public float jumpIterationLimit = 0.5f;
	private float jumpIteration;
	void Jump()
	{
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (isGround)
				jumpControl = true;
		}
		else
			jumpControl = false;
		if (jumpControl && (jumpIteration-=Time.deltaTime) >= 0)
		{
			body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
		else
		{
			jumpIteration = jumpIterationLimit;
			jumpControl = false;
		}
	}
	bool SurfaceCheck(Vector2 direction, Vector2 rayStartPosition, float rayDistance, out bool isSurface, LayerMask surface)
	{
		hit = Physics2D.Raycast(rayStartPosition, direction, rayDistance, surface);
		Ray2D ray = new(rayStartPosition, direction);
		Debug.DrawLine(rayStartPosition, ray.GetPoint(rayDistance), Color.blue);
		if (hit.collider != null)
			isSurface = true;
		else
			isSurface = false;
		return isSurface;
	}
	void FallAcceleration(bool WallSlide)
	{
		if (WallSlide && isWall && body.velocity.y < 0 && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
			body.velocity = new Vector2(body.velocity.x, Physics2D.gravity.y / 3);
		else
			body.gravityScale = !isGround ? Mathf.Lerp(gravityScale, gravityScaleLimit, Time.deltaTime) : gravityScale;
	}

	private bool blockX;
	void Walldrop()
	{
		if (isWall && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
		{
			blockX = true;
		}
		else
		{
			blockX = false;
		}
	}

	void Walljump()
	{

		if (isWall)
		{
			SurfaceCheck(Vector2.down, col.bounds.center, col.bounds.extents.y + 0.5f, out isGround, ground);
			if (!isGround)
				if (Input.GetKeyDown(KeyCode.Space))
				{
					if (isLeftWall)
					{
						body.velocity = new Vector2(Mathf.Cos(Mathf.PI / 3), Mathf.Sin(Mathf.PI / 6));
						body.AddForce(new Vector2(2 * Mathf.Cos(Mathf.PI / 3), 2 * Mathf.Sin(Mathf.PI / 6)) * jumpForce * 10, ForceMode2D.Impulse);
					}
					else
					{
						body.velocity = new Vector2(Mathf.Cos(Mathf.PI / 3) * -1, Mathf.Sin(Mathf.PI / 6));
						body.AddForce(new Vector2(-2 * Mathf.Cos(Mathf.PI / 3), 2 * Mathf.Sin(Mathf.PI / 6)) * jumpForce * 10, ForceMode2D.Impulse);
					}

					blockX = true;
				}
			SurfaceCheck(Vector2.down, col.bounds.center, col.bounds.extents.y + 0.1f, out isGround, ground);
		}
		if (blockX && (blockTime += Time.deltaTime) >= blockDuration)
			if (isWall || isGround || Input.GetAxisRaw("Horizontal") != 0)
			{
				blockX = false;
				blockTime = 0;
			}
	}
}