using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour {

    public int currentWorldState = 0;

	public Stack allowWorldStateShifts = new Stack();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
			if (allowWorldStateShifts.Count == 0)
				currentWorldState = (currentWorldState == 0) ? 1 : 0;
			else
				Debug.Log ("Denied");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}
}
