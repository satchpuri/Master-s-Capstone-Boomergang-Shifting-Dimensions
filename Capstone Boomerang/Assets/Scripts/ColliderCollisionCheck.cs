using UnityEngine;
using System.Collections;

public class ColliderCollisionCheck : MonoBehaviour {


	public int state;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(GameObject.FindObjectOfType<GlobalScript>().currentWorldState!=state && coll.tag=="Player")
			GameObject.FindObjectOfType<GlobalScript> ().allowWorldStateShifts.Push(1);
        else
        {
            Debug.Log(coll.name);
        }
	}

	void OnTriggerExit2D(Collider2D coll) {
        if (GameObject.FindObjectOfType<GlobalScript>().currentWorldState != state && coll.tag == "Player")
			GameObject.FindObjectOfType<GlobalScript> ().allowWorldStateShifts.Pop();
	}
}
