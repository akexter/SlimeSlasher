using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.PingPong(1f, 5)), transform.position.z);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.position.z + Time.deltaTime, transform.rotation.w);
    }
}