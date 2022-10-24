using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float missileSpeed;

    private void Start()
    {
        StartCoroutine(AddnRemove());
    }

    IEnumerator AddnRemove()
    {
        CollisionManager.instance.objInScn.Add(gameObject);
        yield return new WaitForSeconds(3);
        CollisionManager.instance.objInScn.Remove(gameObject);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(transform.up * missileSpeed * Time.deltaTime, Space.World);
    }
}
