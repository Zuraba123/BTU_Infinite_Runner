using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	public Transform player;
	public GameObject platform;	//clone this object in every 50 meters
	public int numberOfStartingPlatforms;

	public Vector3 platformSpawnPoint = Vector3.zero;

	//-------------------- Unity Functions: ------------------------------------
	void Start()
	{
		int counter = 0;

		while (counter < numberOfStartingPlatforms)
		{
			CreateNextPlatform ();
			counter = counter + 1;
		}
	}

	//-------------------- My Custom Functions ------------------------------------
	void CreateNextPlatform()
	{
		Debug.Log ("Creating Platform");

		platformSpawnPoint.z = platformSpawnPoint.z + 50f;

		GameObject clone;
		clone = Instantiate (platform);

		clone.transform.position = platformSpawnPoint;
	}
}
