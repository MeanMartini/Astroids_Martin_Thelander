using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float rotationSpeed, thrustPower;   


    // Update is called once per frame
    void Update()
    {
        RotatePlayer(rotationSpeed);

        transform.Translate(MoveDir() * Time.deltaTime * thrustPower, Space.World);

    }

    private void RotatePlayer(float rotationSpeed)
    {
        Vector3 rotationZ = new Vector3(0f, 0f, Input.GetAxis("Horizontal") * -1f);
        transform.Rotate(rotationZ * Time.deltaTime * rotationSpeed);
    }

    Vector3 moveDir;
    private Vector3 MoveDir()
    {
        if (Input.GetKeyDown("up"))
        {
            moveDir = transform.up + moveDir;
        }

        return moveDir;
    }
}