using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEndWithPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            DataSave.SaveData(new PlayerData()
            {
                currentLevel = currentLevelIndex + 1
            });
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
    }
}
