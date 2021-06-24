using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Vector2 checkPoint;
    float dash;
    float lastDirection;
    float lastHit;
    float goThroughPlatform;

    public bool canBounce;
    public bool canDash;
    public bool fixedVelocity;
    public bool isHit;
    public bool freeze;
    public bool Restart;
   
    public LayerMask layerMask;
    public LayerMask dangerLayerMask;
    public LayerMask platformLayerMask;

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
        if (fixedVelocity == false) // Prevents the player from moving while certain things are happening
        {
            rb.velocity = (new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y));
        }

        if (freeze == true)
        {
            rb.velocity = (new Vector2(0, 0));
        }

        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1) // Records the player's last horizontal direction to use when dashing
        {
            lastDirection = Input.GetAxis("Horizontal");
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

        if (hit.distance <= 0.55f && hit.distance > 0 && hit2.distance <= 0.55f && hit2.distance > 0 && hit3.distance <= 0.55f && hit3.distance > 0) // sets where the player should teleport to if they die
        {
            checkPoint = new Vector2(Mathf.Round(gameObject.transform.position.x) - lastDirection/2, gameObject.transform.position.y);
        }

        if (isHit == true && Time.time >= lastHit + 0.25f) // Changes the player's position after death
        {
            transform.position = checkPoint;
        }

        if (isHit == true && Time.time >= lastHit + 1f) // Allows the player to move after the death transition
        {
            isHit = false;
            freeze = false;
        }

        Jump();

        Dash();

        ThroughPlatform();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

            if (hit.distance <= 0.51f && hit.distance > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(new Vector2(0f, jumpForce));
            }
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.RightShift) && canDash == true) // Dash
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(jumpForce * lastDirection, 0f));
            rb.gravityScale = 0f;
            dash = Time.time;
            canDash = false;
            fixedVelocity = true;
        }

        if (Time.time >= dash + 0.25f && canDash == false) // Ends the dash
        {
            fixedVelocity = false;
            rb.gravityScale = 3f;
        }

        if (Time.time >= dash + 1f) // Allows the player to dash again
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

            if (hit.distance <= 0.55f && hit.distance > 0)
            {
                canDash = true;
            }
        }
    }
    
    void ThroughPlatform()
    {
        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(7, 11, true);
        }
        if (rb.velocity.y <= 0 && Input.GetKey(KeyCode.S) == false && Time.time >= goThroughPlatform + 0.25f)
        {
            Physics2D.IgnoreLayerCollision(7, 11, false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 11, true);
            goThroughPlatform = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D other) // Checks to see if the player is on a moving platform, making the player move with the platform as a result
    {

        if (other.gameObject.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }

        if (other.gameObject.CompareTag("spikes"))
        {
            isHit = true;
            freeze = true;
            lastHit = Time.time;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spikes") || other.gameObject.CompareTag("enemy") && rb.velocity.y > 0f || rb.velocity.y < 0f)
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

        if (other.gameObject.CompareTag("checkpoint"))
        {
            Restart = true;
            isHit = true;
            freeze = true;
            lastHit = Time.time;
            GetComponent<Weapon>().canAttack = false;
            transform.position = new Vector2(0f, 0.5f);
            Restart = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null;
    }
}