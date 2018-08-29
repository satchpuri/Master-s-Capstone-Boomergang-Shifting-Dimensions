using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangManager : MonoBehaviour
{

    public GameObject BoomerangPrefab = null;

    private GameObject boomerangInstance = null;

    private Vector3 toPosition;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            boomerangInstance = Instantiate(BoomerangPrefab, transform.parent, true);
            toPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            Debug.Log(toPosition);
        }

        if (boomerangInstance != null)
        {
            MoveBoomerang();
        }
    }

    void MoveBoomerang()
    {
        var direction = (toPosition - transform.position).normalized;
        direction.z = 0;
        boomerangInstance.transform.Translate(direction * 5F * Time.deltaTime);
    }
}
