using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWarp : MonoBehaviour
{
    [SerializeField] float radius;
    float horizontalBounds;
    float verticalBounds;
    [SerializeField] bool manualRadius;     

    private void Start()
    {
        if(!manualRadius) radius = GetComponent<CircleCollider>().radius;        

        //Finds bounds by calculating aspect ratio multiplied by camera size.
        horizontalBounds = Camera.main.orthographicSize * Screen.width / Screen.height;
        verticalBounds = Camera.main.orthographicSize;
    }

    private void Update()
    {
        WorldWrap();        
    }

    //Moves object to opposite side of screen when it goes outside bounds. 
    //Moves objects by inverting their position.
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

    //Displays radius gizmo.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
