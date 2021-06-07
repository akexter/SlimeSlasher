using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float timer;
    public GameObject Player;


    void Start()
    {
        Player = GameObject.Find("Player");

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void Update()
    {
        gameObject.transform.position = Player.transform.position;
        transform.Translate(1, 0, 0);

        timer += Time.deltaTime;

        if (timer >= 0.25f)
        {
            Player.GetComponent<Weapon>().CanAttack = true;
            Destroy(gameObject);
        }
    }
}
