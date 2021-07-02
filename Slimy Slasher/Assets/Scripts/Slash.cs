using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float timer;
    public GameObject Player;
    public LayerMask layerMask;
    public float angle;

    void Start()
    {
        Player = GameObject.Find("Player");
        gameObject.transform.parent = Player.transform;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(1, 0, 0);

        if (angle >= -112.5 && angle <= -67.5)
        {
            GetComponentInParent<PlayerCtrl>().canBounce = true;
        }

        Player.GetComponent<PlayerAnim>().angle = angle;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.25)
        {
            Destroy(gameObject);
        }
    }
}
