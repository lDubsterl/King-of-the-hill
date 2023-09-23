using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveScript : MonoBehaviour
{
	public Rigidbody2D body;

	protected Collider2D col;

	private Vector2 moveVector;

	public float speed = 8f;

	public float jumpForce = 1300f;

	protected bool isGround;

	protected bool isWall;

	public LayerMask ground;

	public LayerMask wall;

	private RaycastHit2D hit;

	protected float gravityScale;

	protected float gravityScaleLimit;

	public float slideGravity;
	// Start is called before the first frame update
	void Start()
	{
		col = GetComponent<Collider2D>();
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		body = GetComponent<Rigidbody2D>();
		gravityScale = body.gravityScale;
		gravityScaleLimit = gravityScale * 200;
		slideGravity = gravityScale / 2;
		maxAllowedDelay = Time.deltaTime * 4;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		SurfaceCheck(Vector2.down, col.bounds.extents.y + 0.1f, out isGround, ground);
		SurfaceCheck(Vector2.right, col.bounds.extents.x + 0.1f, out isWall, wall);
		SurfaceCheck(Vector2.left, col.bounds.extents.x + 0.1f, out isWall, wall);
		Walldrop();
		Jump();
		FallAcceleration(false);
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
	private float jumpDelay = 0;
	private bool startTimer;
	private float maxAllowedDelay;
	protected void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (isGround)
			{
				body.AddForce(Vector2.up * jumpForce);
				//startTimer = false;
			}
			//else
			//	startTimer = true;
		}
		//if (startTimer && (jumpDelay +=Time.deltaTime) >= maxAllowedDelay && isGround)
		//{ 
		//	body.AddForce(Vector2.up * jumpForce);
		//	jumpDelay = 0;
		//	startTimer = false;
		//}
	}

	protected void SurfaceCheck(Vector2 direction, float rayDistance, out bool isSurface, LayerMask surface)
	{
		hit = Physics2D.Raycast(body.transform.position, direction, rayDistance, surface);
		Ray2D ray = new Ray2D(body.transform.position, direction);
		Debug.DrawLine(body.transform.position, ray.GetPoint(rayDistance), Color.blue);
		if (hit.collider != null)
			isSurface = true;
		else
			isSurface = false;
	}

	public float yVelocity;
	protected void FallAcceleration(bool WallSlide)
	{
		yVelocity = body.velocity.y;
		if (WallSlide && isWall && body.velocity.y < 0 && Input.GetKey(KeyCode.LeftArrow))
			body.velocity = new Vector2(body.velocity.y, Physics2D.gravity.y / 3);
		else
			body.gravityScale = !isGround ? Mathf.Lerp(gravityScale, gravityScaleLimit, Time.deltaTime) : gravityScale;
	}
}
