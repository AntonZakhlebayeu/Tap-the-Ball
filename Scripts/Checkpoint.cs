using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Variables._player))
		{
			Player._LastCheckPoint = this.gameObject;
		}

	}
}
