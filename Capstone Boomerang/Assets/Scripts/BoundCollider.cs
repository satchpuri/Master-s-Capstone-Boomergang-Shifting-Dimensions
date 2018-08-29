using UnityEngine;
using System.Collections;

public class BoundCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.tag);
        if (coll.tag == "Projectile")
        {
            Destroy(coll.gameObject);
        }
    }
}
