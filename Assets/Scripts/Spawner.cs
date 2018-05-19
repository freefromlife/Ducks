using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public Fly enemy;
	public float randY;
	Vector2 wheretospawn;
	public float maxspawnrate = 5;
	public float minspawnrate = 2;
	float nextspawn = 0.0f;
	public GameObject hunter;
	public GameObject SC;
	public GameObject OutOfScreenSpot;
	public float koef = 1;

	public Balloon Balloon;
	public BalloonHealth BalloonHealth;

	public float maxspeed = 2;
	public float minspeed = 1;

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextspawn)
		{
			SpawnDuck();
		}
	}

	private void SpawnDuck()
	{
		var spawnrate = Random.Range(minspawnrate, maxspawnrate) - SC.GetComponent<ScoreCounter>().killed * 0.01f;
		nextspawn = Time.time + spawnrate;
		var rand = Random.Range(-randY, randY);
		wheretospawn = new Vector2(transform.position.x, rand);
		var duck = Instantiate(enemy, wheretospawn, Quaternion.identity);
		duck.hunter = hunter;
		duck.Balloon = Balloon;
		duck.BalloonHealth = BalloonHealth;

		var speed = Random.Range(minspeed, maxspeed);
		koef = SC.GetComponent<ScoreCounter>().killed * 0.02f;
		duck.speed = speed + koef;
		duck.OutOfScreenSpot = OutOfScreenSpot;
	}
}
