using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<GameObject> objInScn = new List<GameObject>();
    [SerializeField] GameObject smallAstroid;
    [SerializeField] GameObject mediumAstroid;


    public static CollisionManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        foreach (GameObject currentObj in objInScn)
        {
            if (currentObj != null)
            {
                CircleCollider thisCollider = currentObj.GetComponent<CircleCollider>();
                foreach (GameObject other in objInScn)
                    if (other != currentObj && other != null)
                    {
                        CircleCollider otherCollider = other.GetComponent<CircleCollider>();

                        if (thisCollider.radius + otherCollider.radius >= DistanceTo(currentObj, other))
                        {
                            //Collision detected!
                            AstroidCollision(other);
                            AstroidCollision(currentObj);

                            if (!other.CompareTag("Missile") && !currentObj.CompareTag("Missile"))
                            {
                                PlayerCollision(other);
                                PlayerCollision(currentObj);
                            }

                            if (!other.CompareTag("Player") && !currentObj.CompareTag("Player"))
                            {
                                MissileCollision(other);
                                MissileCollision(currentObj);
                            }


                        }
                    }
            }
        }
    }

    void AstroidCollision(GameObject obj)
    {
        if (obj.CompareTag("SmallAsteroid"))
        {
            objInScn.Remove(obj);
            Destroy(obj);
        }
        else if (obj.CompareTag("MediumAsteroid"))
        {
            Destroy(obj);
            Instantiate(smallAstroid, obj.transform.position + new Vector3(0.1f, 0.1f), Quaternion.identity);
            Instantiate(smallAstroid, obj.transform.position + new Vector3(-0.1f, -0.1f), Quaternion.identity);
            objInScn.Remove(obj);
        }
        else if (obj.CompareTag("LargeAsteroid"))
        {
            Destroy(obj);
            Instantiate(mediumAstroid, obj.transform.position + new Vector3(0.2f, 0.2f), Quaternion.identity);
            Instantiate(mediumAstroid, obj.transform.position + new Vector3(-0.2f, -0.2f), Quaternion.identity);
            objInScn.Remove(obj);
        }
    }

    void PlayerCollision(GameObject obj)
    {
        if (obj.CompareTag("Player")) GameManager.instance.TakeDamage(); //remove one health
    }

    void MissileCollision(GameObject obj)
    {
        if (obj.CompareTag("Missile"))
        {
            GameManager.instance.AddScore();
            objInScn.Remove(obj);
            Destroy(obj);
        }
    }

    //Uses pythagorean theorem to calc distance to center.
    private float DistanceTo(GameObject a, GameObject b)
    {
        float side1 = Mathf.Abs(a.transform.position.x - b.transform.position.x);
        float side2 = Mathf.Abs(a.transform.position.y - b.transform.position.y);

        float distance;
        distance = Mathf.Sqrt(Mathf.Pow(side1, 2) + Mathf.Pow(side2, 2));

        return distance;
    }
}
