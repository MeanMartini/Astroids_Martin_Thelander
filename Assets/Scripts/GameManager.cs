using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public int health = 3, score = 0;
    private bool clearScene = true;

    private GameObject player;
    public static GameManager instance { get; private set; }

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (clearScene)
        {
            foreach (GameObject obj in CollisionManager.instance.objInScn)
            {
                if (!obj.CompareTag("Player"))
                {
                    CollisionManager.instance.objInScn.Remove(obj);
                    Destroy(obj);
                }
            }
            clearScene = false;
        }
    }

    public void ResetScene()
    {       
        health = 3;
        score = 0;

        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<ShipController>().moveDir = Vector3.zero;

        clearScene = true;
    }

    bool invincibel = false;
    public void TakeDamage()
    {
        if(invincibel == false)
        {
            health -= 1;
            StartCoroutine(Invinciblity());
        }
    }


    IEnumerator Invinciblity()
    {
        invincibel = true;
        yield return new WaitForSeconds(player.GetComponent<ShipController>().invincibilityDuration);
        invincibel = false;
    }

    public void AddScore()
    {
        score += 10;        
    }
    
}
