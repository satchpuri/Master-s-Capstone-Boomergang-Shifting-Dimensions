using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform spawnTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Respawn()
    {
        this.transform.position = spawnTransform.position;
    }
}
