using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<GameObject> objInScn = new List<GameObject>();
    [SerializeField] GameObject smallAstroid;
    [SerializeField] GameObject mediumAstroid;   
    [SerializeField] private Audio audio;

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
        if(!UIManager.instance.paused) DetectCollision();
    }

    //Loops through list of objects in scene and checks distance to eachother.
    //If distance is closer than objA radius + objB radius collision has occured.
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
                            CollisionSwitch(thisCollider, currentObj, other);
                            CollisionSwitch(otherCollider, other, currentObj);
                        }
                    }
            }
            else if (currentObj == null) objInScn.Remove(currentObj);
        }
    }

    //Handels what should happen to object that has collided based on ColliderTyp
    void CollisionSwitch(CircleCollider collider, GameObject obj, GameObject other)
    {
        switch (collider.colliderType)
        {
            case CircleCollider.ColliderType.Asteroid:
                AstroidCollision(obj);
                audio.PlayBoom();
                break;

            case CircleCollider.ColliderType.Missile:
                MissileCollision(obj, other);
                break;

            case CircleCollider.ColliderType.Player:
                PlayerCollision(obj, other);
                break;
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

    void PlayerCollision(GameObject obj, GameObject other)
    {
        if(!other.CompareTag("Missile")) GameManager.instance.TakeDamage(); //remove one health
    }

    void MissileCollision(GameObject obj, GameObject other)
    {
        if (!other.CompareTag("Player"))
        {
            GameManager.instance.AddScore();
            objInScn.Remove(obj);
            Destroy(obj);
        }               
    }   

    //Uses pythagorean theorem to calc distance to center of object a and object b.
    private float DistanceTo(GameObject a, GameObject b)
    {
        float side1 = Mathf.Abs(a.transform.position.x - b.transform.position.x);
        float side2 = Mathf.Abs(a.transform.position.y - b.transform.position.y);

        float distance;
        distance = Mathf.Sqrt(Mathf.Pow(side1, 2) + Mathf.Pow(side2, 2));

        return distance;
    }
}
