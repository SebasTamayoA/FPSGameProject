using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location References")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destroy the casing object")]
    [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")]
    [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")]
    [SerializeField] private float ejectPower = 150f;

    private void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            // Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
        }
    }

    // This function creates the bullet behavior
    private void Shoot()
    {   
        if (GameManager.Instance.gunAmmo > 0)
        {
            GameManager.Instance.gunAmmo --;
        
            if (muzzleFlashPrefab)
            {
                // Create the muzzle flash
                GameObject tempFlash;
                tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

                // Destroy the muzzle flash effect
                Destroy(tempFlash, destroyTimer);
            }

            // Cancel if there's no bullet prefab
            if (!bulletPrefab)
            {
                return;
            }

            // Create a bullet and add force to it in the direction of the barrel
            GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.AddForce(barrelLocation.forward * shotPower);
            }

            // Destroy the bullet after a certain time (in case it doesn't hit anything)
            Destroy(bullet, destroyTimer);
        }
    }

    // This function creates a casing at the ejection slot
    private void CasingRelease()
    {   
        if (GameManager.Instance.gunAmmo > 0)
        {
            // Cancel function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        {
            return;
        }

        // Create the casing
        GameObject tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation);
        Rigidbody casingRigidbody = tempCasing.GetComponent<Rigidbody>();
        if (casingRigidbody != null)
        {
            // Add force on casing to push it out
            casingRigidbody.AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f, 1f);
            // Add torque to make casing spin in random direction
            casingRigidbody.AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        }

        // Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
        }
    }
        
}
