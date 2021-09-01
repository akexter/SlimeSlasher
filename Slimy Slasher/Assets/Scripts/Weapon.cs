using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public bool canAttack;
    public bool weaponUnlocked;
    public float lastAttack;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack == true && weaponUnlocked == true)
        {
            Instantiate(weaponPrefab, transform.position, transform.rotation);
            canAttack = false;
            lastAttack = Time.time;
        }
        if(canAttack == false && weaponUnlocked == true && Time.time >= lastAttack + 0.5)
        {
            canAttack = true;
        }
    }
}