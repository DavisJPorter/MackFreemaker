using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class I_Wanna_Shoot_Stuff : MonoBehaviour
{
    #region Variables
    public float damage = 10f;
    public float range = 100f;
    public Image crosshair;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioClip gunshot;
    AudioSource audioSource;
    #endregion
    //this script obviously goes on the gun
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //This is a default Unity Map. Doesn't need to be set in inputs.
        {
            Shoot();
            GunShotSound();
        }
    }

    void GunShotSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out hit, range))
        {
            // this is essentially a "hitscan" shooting system in which the center player casts a target and sends damage upon interaction with the "Target"
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
    }
}
