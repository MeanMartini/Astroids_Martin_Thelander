using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    [SerializeField] public float radius;

    private void Start()
    {
        CollisionManager.instance.objInScn.Add(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
