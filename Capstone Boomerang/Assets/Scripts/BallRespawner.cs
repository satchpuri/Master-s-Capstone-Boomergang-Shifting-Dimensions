using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
	public class BallRespawner : MonoBehaviour
	{
		public Transform ballSpawn;
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Ball") {
				other.transform.position = ballSpawn.position;

				// Reset velocity
				other.GetComponentInParent<Rigidbody2D> ().isKinematic = true;
				other.GetComponentInParent<Rigidbody2D> ().isKinematic = false;
			}
		}
	}
}
