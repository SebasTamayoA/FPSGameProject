using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public Transform startPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            //add ammo to gun
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            GameManager.Instance.grenades += other.gameObject.GetComponent<AmmoBox>().grenade;
            
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.LoseHealth(5);
        }
    }
}