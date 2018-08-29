using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
	public class LevelEnd : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Ball") {
                DataSave.SaveData(new PlayerData()
                {
                    currentLevel = 2
                });
				SceneManager.LoadScene(2);
			}
		}
	}
}
