using UnityEngine;
using System.Collections;

public class VerticallyMovingPlatform : MonoBehaviour {
    public GameObject MainCameraObject;
    public Vector2 toPoint;
    public Vector2 origPoint;
    public int State;
    public float moveSpeed;
    public bool IsStickyPlatform = true;
    float distance;
    float distanceToSwitch = 0.5f;
    bool reached = false;
    Rigidbody2D platformRigidBody;
    Rigidbody2D playerRigidBody = null;

    // Use this for initialization
    void Start() {
        platformRigidBody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (!reached)
        {
            distance = Vector2.Distance(transform.position, toPoint);
            if (distance > distanceToSwitch)
            {
                move(transform.position, toPoint);
            }
            else
            {
                reached = true;
            }
        }
        else
        {
            distance = Vector2.Distance(transform.position, origPoint);
            if (distance > distanceToSwitch)
            {
                move(transform.position, origPoint);
            }
            else
            {
                reached = false;
            }
        }
    }

    void move(Vector2 pos, Vector2 towards)
    {
        Vector2 direction = (towards - pos).normalized;
        platformRigidBody.MovePosition(platformRigidBody.position + direction * moveSpeed * Time.deltaTime);
        if (IsStickyPlatform && MainCameraObject.GetComponent<GlobalScript>().currentWorldState == State && playerRigidBody != null)
        {
            playerRigidBody.AddForce(new Vector2(direction.x, direction.y * -1f) * moveSpeed * Time.deltaTime);
        }
        else if (MainCameraObject.GetComponent<GlobalScript>().currentWorldState != State)
        {
            playerRigidBody = null;
        }
        //transform.position = Vector3.MoveTowards(pos, towards, .1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rbody = other.GetComponent<Rigidbody2D>();
        if (IsStickyPlatform && rbody != null && other.tag == "Player" && MainCameraObject.GetComponent<GlobalScript>().currentWorldState == State && rbody.velocity.y < 0)
        {
            Debug.Log("BodySet");
            playerRigidBody = rbody;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (IsStickyPlatform && other.GetComponent<Rigidbody2D>() == playerRigidBody && other.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log("BodyUnset");
            playerRigidBody = null;
        }
    }
}
