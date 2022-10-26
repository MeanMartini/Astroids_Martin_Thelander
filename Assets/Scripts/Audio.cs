using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioSource thrusterSound;
    [SerializeField] AudioSource boomSound;

    private void Update()
    {
        PlayLaser();
        PlayThruster();
    }

    public void PlayLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space)) laserSound.Play();
    }

    public void PlayThruster()
    {
        if (Input.GetKeyDown("up")) thrusterSound.Play();
    }

    public void PlayBoom()
    {
        boomSound.Play();
    }


}
