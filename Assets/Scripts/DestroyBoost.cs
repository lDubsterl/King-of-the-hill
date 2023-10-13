using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoost : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) // если другой объект имеет тег "Enemy"
		{
			Destroy(this.gameObject); // уничтожаем другой объект
			BoostSpawner._isBoostExist = false;
		}
	}
}
