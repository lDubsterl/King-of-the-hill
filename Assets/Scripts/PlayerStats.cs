using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class PlayerStats : NetworkBehaviour
{
	public float speed = 8f;

	public float jumpForce = 100f;
}