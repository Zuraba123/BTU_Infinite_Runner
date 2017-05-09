using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	public Transform player;

	void Update ()
	{
		float pp = (int)player.position.z / 50;
	}
}
