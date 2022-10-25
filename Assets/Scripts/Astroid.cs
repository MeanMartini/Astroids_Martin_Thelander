using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;

    [SerializeField] float speed;

    [SerializeField] GameObject spriteRenderer;
    [SerializeField] float rotationSpeed = 1;

    private void Start()
    {
        direction = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10));
    }

    private void Update()
    {
        RandomTranslate();
        RandomRotate();
    }

    private void RandomRotate()
    {
        spriteRenderer.transform.Rotate(Vector3.forward * Random.Range(-1, 1) * Time.deltaTime * rotationSpeed);
    }

    private void RandomTranslate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
