using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    int actualWeapon;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwapKeys();
        //WeaponSwapMouse();
    }

    private void WeaponSwapMouse()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0)
        {
            WeaponSwap(actualWeapon + 1);
        }
        else
        {
            WeaponSwap(actualWeapon - 1);
        }
    }

    private void WeaponSwapKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            WeaponSwap(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            WeaponSwap(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            WeaponSwap(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            WeaponSwap(3);

        }
    }

    private void WeaponSwap(int newWeaponNumber)
    {
        weapons[actualWeapon].SetActive(false);

        if (newWeaponNumber < 0)
        {
            newWeaponNumber = weapons.Length - 1;
        }
        else if (newWeaponNumber > weapons.Length)
        {
            newWeaponNumber = 0;
        }

        weapons[newWeaponNumber].SetActive(true);

        actualWeapon = newWeaponNumber;
    }
}
