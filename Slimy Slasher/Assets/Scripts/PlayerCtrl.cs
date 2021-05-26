using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float distanceGround;
    public Vector3 Checkpoint;

    float move;

    public LayerMask layerMask;

    public GameObject Player;

    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        distanceGround = GetComponent<Collider2D>().bounds.extents.y;
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = (new Vector2(speed * move, rb.velocity.y));

        Jump();
    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space)) // sends a raycast down to check if it hits anything
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

            if (hit.distance <= distanceGround + 0.05f)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, jumpForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) // checks to see if the player is on a platform, making the player move with the platform as a result
    {

        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null;
        DontDestroyOnLoad(transform.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("checkpoint")) // changes the location that the player respawns at
        {
            Checkpoint = other.GetComponent<Transform>().position;
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}