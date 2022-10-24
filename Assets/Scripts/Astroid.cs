using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;

    [SerializeField] float speed;

    private void Start()
    {
        direction = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));
    }

    private void Update()
    {
        RandomTranslate(speed);
    }


    private void RandomTranslate(float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
