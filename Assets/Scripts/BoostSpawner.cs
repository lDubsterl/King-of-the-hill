using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class BoostSpawner : NetworkBehaviour
{
	public GameObject[] boosts;
	public Transform[] spawners;

	private int _boost;
	private int _spawner;
	public static bool _isBoostExist;

	public float _timeBtwSpawns;
	private float _timer;
	public float rayLength;

	private Vector3 _lastSpawn;

	private void Start()
	{
		_timer = _timeBtwSpawns;
		//spawners = GetComponent<Transform[]>();
		//boosts = GetComponent<GameObject[]>();
		//_lastSpawn = GetComponent<Transform>();
		_lastSpawn = new Vector3(0, 0, 0);
	}
	void Update()
	{
		spawnBoost();
	}

	[Server]
	void spawnBoost()
    {

		if (_timer <= 0)
		{

			_spawner = Random.Range(0, spawners.Length);
			if (_lastSpawn != spawners[_spawner].position)
			{
				_boost = Random.Range(0, boosts.Length);
				Collider2D[] colliders = Physics2D.OverlapCircleAll(spawners[_spawner].transform.position, 0.4f);
				if (colliders.Length == 0)
				{
					GameObject boo = Instantiate(boosts[_boost], spawners[_spawner].transform.position, Quaternion.identity);
	 				NetworkServer.Spawn(boo);
					_lastSpawn = spawners[_spawner].transform.position;
					_isBoostExist = true;
					_timer = _timeBtwSpawns;
				}
			}
		}
		if (!_isBoostExist)
			_timer -= Time.deltaTime;

	}

}









/* public GameObject objectPrefab;
	public float spawnRadius = 1f;

	void SpawnObject()
	{
		Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position;
		Collider[] colliders = Physics.OverlapSphere(spawnPosition, 0.1f);
		if (colliders.Length == 0)
		{
			Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
		}
	}*/



//Debug.DrawLine(spawners[_spawner].transform.position, new Vector2(spawners[_spawner].transform.position.x + rayLength, spawners[_spawner].transform.position.y), Color.red);
//Debug.DrawLine(spawners[_spawner].transform.position, new Vector2(spawners[_spawner].transform.position.x - rayLength, spawners[_spawner].transform.position.y), Color.red);
//Debug.DrawLine(spawners[_spawner].transform.position, new Vector2(spawners[_spawner].transform.position.x, spawners[_spawner].transform.position.y + rayLength), Color.red);
//Debug.DrawLine(spawners[_spawner].transform.position, new Vector2(spawners[_spawner].transform.position.x, spawners[_spawner].transform.position.y - rayLength), Color.red);