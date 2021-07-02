using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject Target;

    void Start()
    {
        Target = GameObject.Find("Player");
        gameObject.transform.parent = Target.transform;
    }

    void Update()
    {
        transform.localPosition = new Vector3(-Target.transform.position.x/10, -Target.transform.position.y/10, transform.position.z);
    }
}
