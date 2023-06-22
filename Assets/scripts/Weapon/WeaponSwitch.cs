using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousWeapon = GameManager.Instance.selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (GameManager.Instance.selectedWeapon >= weapons.Length - 1)
            {
                GameManager.Instance.selectedWeapon = 0;
            }
            else
            {
                GameManager.Instance.selectedWeapon++;
            }
            SelectWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (GameManager.Instance.selectedWeapon <= 0)
            {
                GameManager.Instance.selectedWeapon = weapons.Length - 1;
            }
            else
            {
                GameManager.Instance.selectedWeapon--;
            }
            SelectWeapon();
        }

        if (previousWeapon != GameManager.Instance.selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int selectedWeapon = GameManager.Instance.selectedWeapon;
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if(weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (i == selectedWeapon)
                { 
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }
}
