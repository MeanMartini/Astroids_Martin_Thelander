using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float randomX;
    private float randomY;

    private float horizontalBounds;
    private float verticalBounds;

    [SerializeField] float spawnInterval;

    [SerializeField] GameObject[] asteroids;

    private void Start()
    {
        StartCoroutine(Spawn());
        horizontalBounds = Camera.main.orthographicSize * Screen.width / Screen.height;
        verticalBounds = Camera.main.orthographicSize;
    }

    //Randomly spawns asteroids on screen. 
    //Does not check if collision happens at instantiation point. Room for improvement.
    IEnumerator Spawn()
    {
        while (true)
        {
            randomX = Random.Range(horizontalBounds * -1, horizontalBounds);
            randomY = Random.Range(verticalBounds * -1, verticalBounds);
            Instantiate(asteroids[Random.Range(0, 2)], new Vector3(randomX, randomY, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
