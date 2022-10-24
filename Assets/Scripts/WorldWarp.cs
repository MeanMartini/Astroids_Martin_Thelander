using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWarp : MonoBehaviour
{
    float radius;

    private void Start()
    {
        radius = GetComponent<CircleCollider>().radius;
    }

    private void Update()
    {
        WorldWrap();
    }

    //Moves object to opposite side of screen when it goes outside bounds.
    void WorldWrap()
    {
        if (transform.position.x >= 5 + radius || transform.position.x <= -5 - radius)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y);
        }
        if (transform.position.y >= 5 + radius || transform.position.y <= -5 - radius)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1);
        }
    }
}
