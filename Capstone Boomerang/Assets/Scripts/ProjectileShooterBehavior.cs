using UnityEngine;
using System.Collections;

public class ProjectileShooterBehavior : MonoBehaviour {

    public Transform projectile;

    public int shootPeriodInSeconds = 4;
    public float currentPeriod = 0.0f;
	// Use this for initialization
	void Start () {
	
	}

    public bool IsAwake()
    {
        var currentState = GetComponent<ShiftBehaviorScript>().state;
        int worldState = GameObject.FindObjectOfType<GlobalScript>().currentWorldState;
        return (worldState == currentState);
    }
	
	// Update is called once per frame
	void Update () {
        currentPeriod += Time.deltaTime;
        if(currentPeriod>=shootPeriodInSeconds && IsAwake())
        {
            currentPeriod = 0.0f;
            Instantiate(projectile).position = this.transform.position; 
        }
	}
}
