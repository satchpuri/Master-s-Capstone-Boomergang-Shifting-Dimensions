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
    public float BoomerangSpeed = 10F;
    private BoomerangDirection direction;
    private GameObject boomerangInstance = null;
    private Vector3 toPosition;
    private Vector3 positionWhileThrowing;
    float delay = 0F;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && boomerangInstance == null)
        {
            delay = 0F;
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
            Time.timeScale = 0.5F;
            direction = BoomerangDirection.Front;
        }
        else if (Input.GetMouseButtonDown(0) && direction == BoomerangDirection.Front && delay > 0.1F)
        {
            Debug.Log("Change Direction");
            delay = 0F;
            direction = BoomerangDirection.Back;
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
            boomerangInstance.transform.position = boomerangInstance.transform.position + direction * BoomerangSpeed * Time.deltaTime;
        }
        else
        {
            direction = BoomerangDirection.Back;
            Time.timeScale = 0.8F;
            if (boomerangInstance.transform.position.x - transform.position.x > 0.1f)
            {
                var direction = -(toPosition - positionWhileThrowing).normalized;
                boomerangInstance.transform.position = boomerangInstance.transform.position + direction * BoomerangSpeed * Time.deltaTime;
            }
            else
            {
                Time.timeScale = 1F;
                Destroy(boomerangInstance);
            }
        }
    }
}
