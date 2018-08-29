using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float speed = 6.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile hit: " + other.tag);
        if(other.tag=="Player"){
            other.GetComponentInParent<PlayerController>().Respawn();
            Destroy(gameObject);
        }
        
    }
}
