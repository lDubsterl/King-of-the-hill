using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	public bool isObjectIsPlayer;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && isObjectIsPlayer == false)
			Destroy(collision.gameObject);			
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
