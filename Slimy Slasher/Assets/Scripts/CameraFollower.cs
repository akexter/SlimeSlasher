using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Target;

    void Start()
    {
        Target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, gameObject.transform.position.z);
    }
}
