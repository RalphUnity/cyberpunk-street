using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float mSpeed = 10.0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletTrail;
    public Transform firePoint;
    public AudioSource rifleSound;


    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }


    void Shoot()
    {
        muzzleFlash.Play();
        rifleSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);

            GameObject bulletGo = Instantiate(bulletTrail, firePoint.position, firePoint.rotation);
            Destroy(bulletGo, 2f);
        }
    }

}
