using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
	public class BallReset : MonoBehaviour
	{
		public Transform ballSpawn;
		public GameObject ballObject;
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player") {
				ballObject.transform.position = ballSpawn.position;

				// Reset velocity
				ballObject.GetComponentInParent<Rigidbody2D> ().isKinematic = true;
				ballObject.GetComponentInParent<Rigidbody2D> ().isKinematic = false;
			}
		}
	}
}
