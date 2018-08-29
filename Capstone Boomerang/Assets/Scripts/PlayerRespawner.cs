using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
	public class PlayerRespawner : MonoBehaviour
	{
		public Transform playerSpawn;
		private void OnTriggerEnter2D(Collider2D other)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			if(other.tag=="Player")
				other.transform.position = playerSpawn.position;
		}
	}
}