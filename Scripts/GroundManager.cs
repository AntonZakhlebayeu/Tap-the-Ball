using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
	public int ExistsGroundParts;
	public GameObject GroundPartDefault;
	public List<GameObject> GroundParts;
	public static GameObject _LastGroundPart;
	public static List<GameObject> _GroundParts = new List<GameObject>();
	public static List<GameObject> _ActiveGroundParts = new List<GameObject>();

	private GameObject Player;
	private Vector3 SpawnPosition = new Vector3(0, 0, 0);
	private Transform PlayerTransform;
	private Transform FirstGroundPartTransform;
	private BoxCollider FirstGroundPartBoxCollider;
	private static GameObject _Road;
	private static int _LastGroundPartChoice = 0;

	private Vector3 SpawnDefaultGroundPart(Vector3 SpawnPosition)
	{

		GameObject GroundPart = Instantiate(GroundPartDefault);

		float ObjectHeightTemp = GroundPartDefault.GetComponent<BoxCollider>().size.z;

		GroundPart.transform.parent = _Road.transform;
		GroundPart.GetComponent<Transform>().position = SpawnPosition;

		SpawnPosition += new Vector3(0, 0, ObjectHeightTemp);
		_ActiveGroundParts.Add(GroundPart);

		return SpawnPosition;

	}

	private static void SpawnGroundPart()
	{

		int GroundPartChoice;

		do
		{
			GroundPartChoice = Random.Range(0, _GroundParts.Count);
		} while (GroundPartChoice == _LastGroundPartChoice);

		_LastGroundPartChoice = GroundPartChoice;

		GameObject GroundPart = _GroundParts[GroundPartChoice];
		GameObject GroundPartInstance = Instantiate(GroundPart);

		GroundPartInstance.transform.parent = _Road.transform;

		float GroundPartSize = _LastGroundPart.GetComponent<BoxCollider>().size.z;

		Vector3 LastGroundPartPosition = _LastGroundPart.GetComponent<Transform>().position;
		Vector3 GroundPosition = LastGroundPartPosition + new Vector3(0, 0, GroundPartSize);

		GroundPartInstance.GetComponent<Transform>().position = GroundPosition;
		_LastGroundPart = GroundPartInstance;
		_ActiveGroundParts.Add(GroundPartInstance);

	}

	private void SpawnGroundPart(GameObject GroundPart, Vector3 GroundPartPosition)
	{

		GameObject GroundPartInstance = Instantiate(GroundPart);
		GroundPartInstance.transform.parent = this.gameObject.transform;
		GroundPartInstance.GetComponent<Transform>().position = GroundPartPosition;
		_LastGroundPart = GroundPartInstance;
		_ActiveGroundParts.Add(GroundPartInstance);

	}

	private void Awake()
	{
		foreach (GameObject GroundPart in GroundParts)
			_GroundParts.Add(GroundPart);
	}

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");

		GroundManager._ActiveGroundParts.Clear();

		_Road = this.gameObject;

		SpawnPosition = SpawnDefaultGroundPart(SpawnPosition);

		for (int i = 0; i < ExistsGroundParts; i++)
		{
			int GroundPartChoice = Random.Range(0, _GroundParts.Count);
			SpawnGroundPart(_GroundParts[GroundPartChoice], SpawnPosition);
			float ObjectHeight = _GroundParts[GroundPartChoice].GetComponent<BoxCollider>().size.z;
			SpawnPosition += new Vector3(0, 0, ObjectHeight);
		}

	}

	private void Update()
	{
		if (!Variables._IsGameOver)
		{
			PlayerTransform = Player.GetComponent<Transform>();
			FirstGroundPartTransform = _ActiveGroundParts[0].GetComponent<Transform>();
			FirstGroundPartBoxCollider = _ActiveGroundParts[0].GetComponent<BoxCollider>();

			if (PlayerTransform.position.z > FirstGroundPartTransform.position.z + FirstGroundPartBoxCollider.size.z + 50)
			{
				Destroy(_ActiveGroundParts[0]);
				_ActiveGroundParts.RemoveAt(0);
				SpawnGroundPart();
				Variables._IsSpawnRoadPart = true;
			}
		}
	}

}
