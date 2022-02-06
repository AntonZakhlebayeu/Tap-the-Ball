using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpandingWall : Wall
{
	private int _Direction = 1;
	private float _ExpandCooldown = 0.8f;
	private float ExpandingWallSpeed = 0.03f;
	private float _GroundPartWidth;
	private float _WallWidth;
	private float ScaleX;

	private void Start()
	{
		_GroundPartWidth = GroundManager._LastGroundPart.GetComponent<BoxCollider>().size.x;
		_WallWidth = this.gameObject.GetComponent<BoxCollider>().size.x;
	}

	private void Update()
	{

		if (!Variables._MovementIsStoped)
		{
			ScaleX = this.gameObject.GetComponent<Transform>().transform.localScale.x;

			if (_ExpandCooldown < 0 && (ScaleX + _WallWidth / 2 > _GroundPartWidth / 2 || ScaleX - _WallWidth / 2 < _GroundPartWidth / -2))
			{
				_Direction *= -1;
				_ExpandCooldown = 0.8f;

			}

			this.gameObject.transform.localScale += new Vector3(ExpandingWallSpeed * Time.deltaTime * _Direction, 0, 0);
			_ExpandCooldown -= Time.deltaTime;
		}
	}
}
