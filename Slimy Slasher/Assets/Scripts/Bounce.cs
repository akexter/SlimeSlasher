using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public LayerMask layerMask;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

        if (hit.distance <= 0.55f && hit.distance > 0 && transform.rotation.z <= -50 && transform.rotation.z >= -130)
        {
         //   Player.GetComponent<PlayerCtrl>().Bounce = true; //
            Destroy(GetComponent<Bounce>());
        }
        else
        {
            return;
        }
    }
}
