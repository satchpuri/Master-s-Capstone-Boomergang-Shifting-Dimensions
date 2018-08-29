using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResumeController : MonoBehaviour {

    private int levelToLoad = 1;
	// Use this for initialization
	void Start () {
        var data = DataSave.LoadData();
        if (data == null)
        {
            Destroy(gameObject);
        }
	}

    public void loadLevel()
    {
        var data = DataSave.LoadData();
        SceneManager.LoadScene(data.currentLevel);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
