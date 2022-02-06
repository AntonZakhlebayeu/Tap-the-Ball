using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "Player")
		{
			General.GameOver(TypeOfDeath.Collision);
		}
	}

}
