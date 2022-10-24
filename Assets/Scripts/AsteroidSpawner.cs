using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float randomX;
    private float randomY;
    [SerializeField] float spawnInterval;

    [SerializeField] GameObject[] astroids;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            randomX = Random.Range(-5, 5);
            randomY = Random.Range(-5, 5);
            Instantiate(astroids[Random.Range(0, 2)], new Vector3(randomX, randomY, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
