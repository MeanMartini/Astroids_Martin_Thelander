using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float parallaxAmount;
    private GameObject player;
    private Vector3 moveDir;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ParallaxMover();
    }

    void ParallaxMover()
    {
        moveDir = player.GetComponent<ShipController>().moveDir;
        transform.Translate(moveDir * -1 * parallaxAmount * Time.deltaTime);
    }
}
