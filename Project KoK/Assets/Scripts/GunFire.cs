using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    public GameObject Flash;

    // Update is called once per frame
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AudioSource gunSound = GetComponent<AudioSource>();
                gunSound.Play();
                Flash.SetActive(true);
                StartCoroutine(MuzzleOff());
                GetComponent<Animation>().Play("GunShot");
                GlobalAmmo.LoadedAmmo -= 1;
            }
        }
    }

    public IEnumerator MuzzleOff()
    {
        yield return new WaitForSeconds(0.15f);
        Flash.SetActive(false);
    }
}
