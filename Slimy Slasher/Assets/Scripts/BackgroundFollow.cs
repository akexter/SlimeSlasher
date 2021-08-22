using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject Target;

    void Start()
    {
        Target = GameObject.Find("Player");
    }

    void Update()
    {
            gameObject.transform.parent = Target.transform;
            transform.localPosition = new Vector3(-Target.transform.position.x / 10, -Target.transform.position.y / 10, transform.position.z);
    }
}
