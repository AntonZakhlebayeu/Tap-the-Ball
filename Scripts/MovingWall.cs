using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingWall : Wall
{

	private int _Direction = 1;
	private float MovingWallSpeed = 2f;
	private float _RotateCooldown = 0.1f;
	private float _GroundPartWidth;
	private float _WallWidth;
	private float PositionX;

	private void Start()
	{
		_GroundPartWidth = GroundManager._LastGroundPart.GetComponent<BoxCollider>().size.x;
		_WallWidth = this.gameObject.GetComponent<BoxCollider>().size.x;
	}

	private void Update()
	{

		if (!Variables._MovementIsStoped)
		{
			PositionX = this.gameObject.GetComponent<Transform>().transform.position.x;

			if (_RotateCooldown < 0 && (PositionX + _WallWidth / 2 > _GroundPartWidth / 2 || PositionX - _WallWidth / 2 < _GroundPartWidth / -2))
			{
				_Direction *= -1;
				_RotateCooldown = 0.1f;

			}

			this.gameObject.transform.position += new Vector3(MovingWallSpeed * Time.deltaTime * _Direction, 0, 0);
			_RotateCooldown -= Time.deltaTime;
		}

	}

}
