using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangManager : MonoBehaviour
{
    enum BoomerangDirection
    {
        Front, Back
    };

    public GameObject BoomerangPrefab = null;
    private BoomerangDirection direction;
    private GameObject boomerangInstance = null;
    private Vector3 toPosition;
    private Vector3 positionWhileThrowing;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (boomerangInstance != null)
            {
                Destroy(boomerangInstance);
            }

            boomerangInstance = Instantiate(BoomerangPrefab, transform.position, transform.rotation);
            toPosition = new Vector3(4, -1, 0);
            var mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;
            toPosition = Camera.main.ScreenToWorldPoint(mousePos);
            toPosition.z = 0;
            positionWhileThrowing = transform.position;
            Debug.Log(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
            direction = BoomerangDirection.Front;
        }
        if (boomerangInstance != null)
        {
            MoveBoomerang();
        }
    }

    void MoveBoomerang()
    {
        if ((boomerangInstance.transform.position - toPosition).magnitude > 0.1f && direction == BoomerangDirection.Front)
        {
            var direction = (toPosition - positionWhileThrowing).normalized;
            boomerangInstance.transform.position = boomerangInstance.transform.position + direction * 5F * Time.deltaTime;
        }
        else
        {
            direction = BoomerangDirection.Back;
            if(boomerangInstance.transform.position.x - transform.position.x > 0.1f)
            {
                var direction = -(toPosition - positionWhileThrowing).normalized;
                boomerangInstance.transform.position = boomerangInstance.transform.position + direction * 5F * Time.deltaTime;
            }
            else
            {
                Destroy(boomerangInstance);
            }
        }

    }
}
