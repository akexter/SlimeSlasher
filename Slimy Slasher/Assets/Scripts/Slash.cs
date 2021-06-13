using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float timer;
    public GameObject Player;
    public LayerMask layerMask;

    void Start()
    {
        Player = GameObject.Find("Player");
        gameObject.transform.parent = Player.transform;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(1, 0, 0);

        if (transform.rotation.z >= -0.9 && transform.rotation.z <= -0.4)
        {
            GetComponentInParent<PlayerCtrl>().canBounce = true;
        }

    }
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 0.25)
        {
            Player.GetComponent<Weapon>().canAttack = true;
            Destroy(gameObject);
        }
    }
}
