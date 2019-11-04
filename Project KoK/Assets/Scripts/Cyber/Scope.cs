using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;

    public GameObject scopeOverlay;
    public GameObject crossHair;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopedFOV = 15f;

    private float normalFOV;
    private bool isScoped = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            //scopeOverlay.SetActive(isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnscoped();
            }
            //if (isScoped == true)
            //{
            //    animator.SetBool("Scoped", true);
            //    mainCamera.fieldOfView = 15f;
            //}
            //else
            //{
            //    animator.SetBool("Scoped", false);
            //    mainCamera.fieldOfView = 60f;
            //}
        }
    }



    //SNIPER ZOOM

    void OnUnscoped()
    {
        crossHair.SetActive(true);
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);

        crossHair.SetActive(false);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }
}
