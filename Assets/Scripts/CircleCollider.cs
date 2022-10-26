using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    [SerializeField] public float radius;
    public ColliderType colliderType;

    private void Start()
    {
        CollisionManager.instance.objInScn.Add(gameObject);
    }

    public enum ColliderType
    {
        Asteroid,
        Player,
        Missile,
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
