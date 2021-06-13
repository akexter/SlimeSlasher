using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public bool canAttack;
    void Start()
    {
        canAttack = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack == true)
        {
            Instantiate(weaponPrefab, transform.position, transform.rotation);
            canAttack = false;
        }
    }
}