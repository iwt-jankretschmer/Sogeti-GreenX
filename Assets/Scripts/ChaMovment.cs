using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaMovment : MonoBehaviour
{
	public float speed;
	
	public static Waypoints Wpoints;

	private int waypointIndex = 0;
	


	public void Start()
	{
		Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
	}
	

	void Update()
	{
		print(waypointIndex.ToString() );
		transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position,
			speed * Time.deltaTime);

		if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
		{
			if (waypointIndex < Wpoints.waypoints.Length - 1)
			{
				waypointIndex++;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
