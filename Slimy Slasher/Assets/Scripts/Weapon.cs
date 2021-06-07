using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public bool CanAttack;
    void Start()
    {
        CanAttack = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanAttack == true)
        {
            Instantiate(weaponPrefab, transform.position, transform.rotation);
            CanAttack = false;
        }

    }
}