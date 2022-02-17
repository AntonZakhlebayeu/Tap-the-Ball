using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public static bool _IsDropped = false;
	public static bool _IsGameOver = false;
	public static bool _IsTapped = false;
	public static float _VerticalSpeed_backup;
	public static GameObject _LastCheckPoint;
	
	private int _Direction = 1;
	private float PositionX;
	private float GroundSize;
	private float PlayerWidth;
	private Vector3 DeltaPosition;
	private GameObject MainCamera;

	private void Start()
	{
		MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

		_IsGameOver = false;
		_IsDropped = false;
		_IsTapped = false;

		PlayerWidth = this.gameObject.GetComponent<SphereCollider>().radius * 2;
	}

	private void Update()
	{

		if (!Variables._MovementIsStoped)
		{

			DeltaPosition = new Vector3(Variables._HorizontalSpeed * _Direction * Time.deltaTime, 0, Variables._VerticalSpeed * Time.deltaTime);
			this.gameObject.GetComponent<Transform>().position += DeltaPosition;
			this.gameObject.GetComponent<Transform>().transform.Rotate(0, 0, -1 * Variables._HorizontalSpeed * _Direction * Time.deltaTime * 360 / (2 * PlayerWidth / 2 * Mathf.PI), Space.World);
			this.gameObject.GetComponent<Transform>().transform.Rotate(Variables._VerticalSpeed * Time.deltaTime * 360 / (2 * Mathf.PI * PlayerWidth / 2), 0, 0, Space.World);
			MainCamera.GetComponent<Transform>().position += new Vector3(0, 0, Variables._VerticalSpeed * Time.deltaTime);


			if (Variables._HorizontalSpeed <= 23.0 && Variables._VerticalSpeed <= 23.0 && _IsTapped == true)
			{
				Variables._HorizontalSpeed += Variables._SpeedMultiplicator * Time.deltaTime;
				Variables._VerticalSpeed += Variables._SpeedMultiplicator * Time.deltaTime;
			}


			PositionX = this.gameObject.GetComponent<Transform>().position.x;
			GroundSize = GroundManager._LastGroundPart.GetComponent<BoxCollider>().size.x;


			if (PositionX > GroundSize / 2 + PlayerWidth / 2 || PositionX < -GroundSize / 2 - PlayerWidth / 2)
			{
				if (!_IsGameOver)
				{
					_VerticalSpeed_backup = Variables._VerticalSpeed;

					Variables._VerticalSpeed /= 3;
					Variables._HorizontalSpeed /= 3;
					gameObject.GetComponent<TrailRenderer>().enabled = false;
					General.GameOver(TypeOfDeath.Falling);
					_IsDropped = true;
					_IsGameOver = true;
				}
			}


			if (Input.GetKeyDown(KeyCode.Tab) && !_IsDropped)
			{
				_Direction *= -1;
				if (!_IsTapped)
				{
					_IsTapped = true;
					Variables._HorizontalSpeed = Variables._VerticalSpeed;
					UIManager.DisableGuide();
				}
				DataManager.SaveTotalTaps();
			}

			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began && !_IsDropped)
				{
					_Direction *= -1;
					if (!_IsTapped)
					{
						_IsTapped = true;
						Variables._HorizontalSpeed = Variables._VerticalSpeed;
						UIManager.DisableGuide();
					}
					DataManager.SaveTotalTaps();
				}
			}

		}

	}
}
