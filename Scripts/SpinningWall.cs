using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinningWall : Wall
{

	private float SpinningWallSpeed = 0.2f;

	private void Start()
	{
		this.gameObject.transform.Rotate(0, 360 * Random.Range(0f, 1.0f), 0);
	}

	private void Update()
	{
		if (!Variables._MovementIsStoped)
			this.gameObject.transform.Rotate(0, 360 * Time.deltaTime * SpinningWallSpeed, 0);
	}

}
