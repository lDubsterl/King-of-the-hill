using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
	public string Name;
	public float Multiplier;

	public Buff(string name, float multiplier)
	{
		Name = name;
		Multiplier = multiplier;
	}
}

public class ChangeStats : MonoBehaviour
{
	private Move move;
	private float oldSpeed;
	private float oldJumpForce;
	public float duration = 10;
	public Buff[] buffInfo =    {
		new Buff("Speed",  1.5f),
		new Buff("Jump", 1.5f)
	};
	private Dictionary<string, float> multipliers = new();
	private float timer = 0;
	private bool isPickedUp = false;
	private string currentBoost;
	private void Start()
	{
		move = GetComponent<Move>();
		for(int i = 0; i < buffInfo.Length; i++)
			multipliers.Add(buffInfo[i].Name, buffInfo[i].Multiplier);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isPickedUp)
		{
			currentBoost = collision.gameObject.tag;
			isPickedUp = true;
			switch (currentBoost)
			{
				case "SpeedBoost":
					{
						oldSpeed = move.speed;
						move.speed *= multipliers.GetValueOrDefault("Speed");
						break;
					}
				case "JumpBoost":
					{
						oldJumpForce = move.jumpForce;
						move.jumpForce *= multipliers.GetValueOrDefault("Jump");
						break;
					}
				case "InvulnerabilityBoost": break;
				default: isPickedUp = false; break;
			}
		}
	}
	void FixedUpdate()
	{
		if (isPickedUp && ((timer += Time.deltaTime) >= duration))
		{
			switch (currentBoost)
			{
				case "SpeedBoost":
					{
						move.speed = oldSpeed;
						break;
					}
				case "JumpBoost":
					{
						move.jumpForce = oldJumpForce;
						break;
					}
				case "InvulnerabilityBoost": break;
			}
			timer = 0;
			isPickedUp = false;
		}
	}
}
