using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWarp : MonoBehaviour
{
    float radius;
    float horizontalBounds;
    float verticalBounds;
      

    private void Start()
    {
        radius = GetComponent<CircleCollider>().radius;
        horizontalBounds = Camera.main.orthographicSize * Screen.width / Screen.height;
        verticalBounds = Camera.main.orthographicSize;
    }

    private void Update()
    {
        WorldWrap();        
    }

    //Moves object to opposite side of screen when it goes outside bounds.
    void WorldWrap()
    {
        //Horizontal bounds
        if (transform.position.x >= horizontalBounds + radius || transform.position.x <= horizontalBounds * -1 - radius)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y);
        }
        //Vertical bounds
        if (transform.position.y >= verticalBounds + radius || transform.position.y <= verticalBounds * -1 - radius)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1);
        }
    }
}
