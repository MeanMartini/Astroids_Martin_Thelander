using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float rotationSpeed, thrustPower;
    public float invincibilityDuration; //Time in seconds where player can't take damage after being hit by asteroid.

    [SerializeField] GameObject missile;
    [SerializeField] GameObject thrusterSprite;
    [SerializeField] float thrustAnimDuration;

    // Update is called once per frame
    void Update()
    {
        RotatePlayer(rotationSpeed);
        transform.Translate(MoveDir() * Time.deltaTime * thrustPower, Space.World);

        FireMissile();
    }

    private void RotatePlayer(float rotationSpeed)
    {
        Vector3 rotationZ = new Vector3(0f, 0f, Input.GetAxis("Horizontal") * -1f);
        transform.Rotate(rotationZ * Time.deltaTime * rotationSpeed);
    }

    [HideInInspector] public Vector3 moveDir;
    private Vector3 MoveDir()
    {
        if (Input.GetKeyDown("up"))
        {
            moveDir = transform.up + moveDir;
            StartCoroutine(ThrusterAnim());
        }

        return moveDir;
    }

    IEnumerator ThrusterAnim()
    {
        thrusterSprite.SetActive(true);
        yield return new WaitForSeconds(thrustAnimDuration);
        thrusterSprite.SetActive(false);
    }

    private void FireMissile()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, transform.position, transform.rotation);
        }

    }
}
