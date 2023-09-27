using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveScript : MonoBehaviour
{
	protected Rigidbody2D body;

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
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		col = GetComponent<Collider2D>();
		body = GetComponent<Rigidbody2D>();
		gravityScale = body.gravityScale;
		gravityScaleLimit = gravityScale * 200;
		slideGravity = gravityScale / 2;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		SurfaceCheck(Vector2.down, col.bounds.extents.y + 0.1f, out isGround, ground);
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

	private bool jumpControl;
	private float jumpIteration = 0;
	public float jumpIterationLimit = 15;

	protected void Jump()
	{
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (isGround)
				jumpControl = true;
		}
		else
			jumpControl = false;
		if (jumpControl && (jumpIteration++ < jumpIterationLimit))
		{
			body.AddForce(Vector2.up, ForceMode2D.Impulse);
		}
		else
		{
			jumpIteration = 0;
			jumpControl = false;
		}
	}
	protected void SurfaceCheck(Vector2 direction, float rayDistance, out bool isSurface, LayerMask surface)
	{
		hit = Physics2D.Raycast(body.transform.position, direction, rayDistance, surface);
		Ray2D ray = new(body.transform.position, direction);
		Debug.DrawLine(body.transform.position, ray.GetPoint(rayDistance), Color.blue);
		if (hit.collider != null)
			isSurface = true;
		else
			isSurface = false;
	}
	protected void FallAcceleration(bool WallSlide)
	{
		if (WallSlide && isWall && body.velocity.y < 0 && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
			body.velocity = new Vector2(body.velocity.x, Physics2D.gravity.y / 3);
		else
			body.gravityScale = !isGround ? Mathf.Lerp(gravityScale, gravityScaleLimit, Time.deltaTime) : gravityScale;
	}
}
