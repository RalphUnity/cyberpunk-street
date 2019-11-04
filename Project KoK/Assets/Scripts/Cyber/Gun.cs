using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float bulletSpeed = 5000;
    public float fireRate = 15f;

    List<GameObject> bulletList;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public ParticleSystem muzzleFlash;
    public AudioSource bulletAudio;
    public GameObject bullet;
    public GameObject scopeOverlay;
    public Camera mainCamera;

    private float nextTimeToFire = 0f;

    public Animator animator;
    public Animator scopeAnimator;

    void Start()
    {
        currentAmmo = maxAmmo;

        bulletList = new List<GameObject>();
        for(int i = 0; i < 30; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        //scopeOverlay.SetActive(false);
        //scopeAnimator.SetBool("Scoped", false);
        animator.SetBool("Reloading", true);
        //mainCamera.fieldOfView = 60f;

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        //Shoot

        for(int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                break;
            }
        }

        //Play Audio
        bulletAudio.Play();
    }

}
