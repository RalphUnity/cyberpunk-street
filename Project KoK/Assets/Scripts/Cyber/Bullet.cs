using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 10f;
    public GameObject impactEffect;

    private ContactPoint contact;
    private Quaternion rot;
    private Vector3 pos;

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        //Invoke("hideBullet",2.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }

    
    void OnCollisionEnter(Collision collision)
    {
        //Physics.IgnoreCollision(charCon, bombTra.GetComponent<Collider>());
        if (collision.transform.tag == "Enemy")
        {
            Target target = collision.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }


            
        }

        contact = collision.contacts[0];
        rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        pos = contact.point;
        var impactEffectGO = Instantiate(impactEffect, pos, rot);
        gameObject.SetActive(false);
    }


}

