using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Vector2 checkPoint;
    float move;

    public bool Bounce = false;

    public LayerMask layerMask;

    public GameObject Player;

    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = (new Vector2(speed * move, rb.velocity.y));

        Jump();

        if(Bounce == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce / 2));
            Bounce = false;
        }
    }
    void Jump()
    {

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 1f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 1f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

        if (hit2.distance <= 0.55f && hit2.distance > 0 && hit3.distance <= 0.55f && hit3.distance > 0) // sets where the player should teleport to if they die
        {
            checkPoint = gameObject.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.distance <= 0.55f && hit.distance > 0)
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

        if (other.gameObject.CompareTag("checkpoint"))
        {
            checkPoint = other.GetComponent<Transform>().position;
        }

        if (other.gameObject.CompareTag("spikes"))
        {
            gameObject.transform.position = checkPoint;
        }
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}