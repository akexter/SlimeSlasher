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
    float dash;
    float lastDirection;
    float lastHit;

    public bool canBounce;
    public bool canDash;
    public bool fixedVelocity;
    public bool isHit;

    public LayerMask layerMask;
    public LayerMask floorLayerMask;
    public LayerMask dangerLayerMask;

    public GameObject Player;

    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        canDash = true;
        speed = 4;
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (fixedVelocity == false)
        {
            rb.velocity = (new Vector2(speed * move, rb.velocity.y));
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

        if (Time.time >= dash + 0.25f && canDash == false)
        {
            fixedVelocity = false;
            rb.gravityScale = 3f;
        }

        if (hit.distance <= 0.51f && hit.distance > 0 && Time.time >= dash + 1f)
        {
            canDash = true;
        }

        if (hit2.distance <= 0.51f && hit2.distance > 0)
        {
            Physics2D.IgnoreLayerCollision(7, 11, false);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(7, 11, true);
        }

        if (isHit == true && Time.time >= lastHit + 0.25f)
        {
            transform.position = checkPoint;
        }

        if (isHit == true && Time.time >= lastHit + 1f)
        {
            isHit = false;
            fixedVelocity = false;
            transform.position = checkPoint;
        }

        if (move == 1 || move == -1)
        {
            lastDirection = move;
        }

        Jump();

        Dash();

    }
    void Jump()
    {

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

        if (hit2.distance <= 0.51f && hit2.distance > 0 && hit3.distance <= 0.51f && hit3.distance > 0) // sets where the player should teleport to if they die
        {
            checkPoint = new Vector2(Mathf.Round(gameObject.transform.position.x), gameObject.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.distance <= 0.51f && hit.distance > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, jumpForce));
            }
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.RightShift) && canDash == true)
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(jumpForce * lastDirection, 0f));
            rb.gravityScale = 0f;
            dash = Time.time;
            canDash = false;
            fixedVelocity = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other) // checks to see if the player is on a platform, making the player move with the platform as a result
    {

        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }

        if (other.gameObject.CompareTag("spikes") || other.gameObject.CompareTag("enemy"))
        {
            isHit = true;
            fixedVelocity = true;
            lastHit = Time.time;
            rb.AddForce(new Vector2(-lastDirection * jumpForce / 2, jumpForce /2));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spikes") || other.gameObject.CompareTag("enemy"))
        {
            if (GetComponent<Weapon>().canAttack == false && canBounce == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, 2 * jumpForce / 3));
                canBounce = false;
            }
        }

        if (other.gameObject.CompareTag("item"))
        {
            if (other.gameObject.name == "SlashObtainer")
            {
                GetComponent<Weapon>().canAttack = true;
            }
            other.gameObject.GetComponent<ItemDisappear>().isTriggered = true;
        }

        if (other.gameObject.CompareTag("secret"))
        {
            other.gameObject.GetComponent<SecretActivator>().isTriggered = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null;
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}