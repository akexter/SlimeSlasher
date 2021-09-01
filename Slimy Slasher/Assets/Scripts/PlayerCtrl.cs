using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float lastDirection;
    public float dash;
    public float lastHit;
    public float lastGravity;
    float goThroughPlatform;

    public bool canBounce;
    public bool canDash;
    public bool dashUnlocked;
    public bool fixedVelocity;
    public bool isHit;
    public bool enemyHit;
    public bool freeze;
    public bool start;

    public LayerMask layerMask;
    public LayerMask dangerLayerMask;
    public LayerMask platformLayerMask;

    public Vector2 checkPoint;
    public Vector2 startPoint;

    Rigidbody2D rb;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        lastDirection = 1;
        startPoint = transform.position;
        lastGravity = rb.gravityScale;
        dashUnlocked = false;
    }

    void Update()
    {
        if (Time.time > 0.62f && start == false)
        {
            start = true;
        }

        if (fixedVelocity == false && start == true) // Prevents the player from moving while certain things are happening
        {
            rb.velocity = (new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y));
        }

        if (freeze == true)
        {
            rb.velocity = (new Vector2(0, 0));
        }

        if (rb.velocity.x > 0)
        {
            lastDirection = 1;
        }
        if (rb.velocity.x < 0) // Records the player's last horizontal direction
        {
            lastDirection = -1;
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.75f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, dangerLayerMask);

        if (hit.distance <= 0.51f && hit.distance > 0.45f && hit2.distance <= 0.51f && hit2.distance > 0.45f && hit3.distance <= 0.51f && hit3.distance > 0.45f && Time.time > lastHit + 5f && hit4.distance > 1f) // sets where the player should teleport to if they die
        {
            checkPoint = new Vector2(Mathf.Round(gameObject.transform.position.x) - lastDirection / 2, gameObject.transform.position.y);
        }

        if (isHit == true && Time.time >= lastHit + 1f && Time.time < lastHit + 1.1f && GetComponent<PlayerHealth>().health > 0) // Changes the player's position after touching spikes
        {
            transform.position = checkPoint;
        }

        if (isHit == true && Time.time >= lastHit + 1.1f && Time.time <= lastHit + 1.2f && GetComponent<PlayerHealth>().health <= 0) // Changes the player's position to the start after dying
        {
            SceneManager.LoadScene("Main Game", LoadSceneMode.Single);
        }

        if (Time.time >= lastHit + 2f && isHit == true && GetComponent<PlayerHealth>().health > 0) // Allows the player to move after the death transition
        {
            enemyHit = false;
            fixedVelocity = false;
            isHit = false;
            freeze = false;
        }

        if (hit.distance <= 0.55f && enemyHit == true && GetComponent<PlayerHealth>().health > 0)
        {
            fixedVelocity = false;
            enemyHit = false;
            isHit = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.rotation = 0f;
            Physics2D.IgnoreLayerCollision(7, 8, false);
        }

        if (GetComponent<PlayerHealth>().health <= 0)
        {
            isHit = true;
        }

        Jump();

        Dash();

        ThroughPlatform();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (fixedVelocity == false && start == true)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
                RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.125f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);
                RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x - 0.125f, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

                if (hit.distance <= 0.51f && hit.distance > 0 || hit2.distance <= 0.51f && hit2.distance > 0 || hit3.distance <= 0.51f && hit3.distance > 0) // Intiates the jump
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
        }
    }
    void Dash()
    {
        if (dashUnlocked == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) // Initiates the dash
            {
                if (canDash == true && start == true && Time.time >= dash + 1f)
                {
                    if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
                    {
                        lastDirection = Input.GetAxis("Horizontal");
                    }

                    canDash = false;
                    fixedVelocity = true;
                    rb.velocity = new Vector2(16f * lastDirection, 0f);
                    rb.gravityScale = 0f;
                    dash = Time.time;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
            }

            if (Time.time >= dash + 0.25f && canDash == false) // Ends the dash
            {
                fixedVelocity = false;
                rb.gravityScale = lastGravity;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.rotation = 0f;
            }

            if (Time.time >= dash + 1f && canDash == false) // Allows the player to dash again
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, Mathf.Infinity, layerMask);

                if (hit.distance <= 0.55f && hit.distance > 0)
                {
                    canDash = true;
                }
            }
        }
    }

    void ThroughPlatform()
    {
        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(7, 12, true);
        }
        if (rb.velocity.y < 0 && Input.GetKey(KeyCode.S) == false && Time.time >= goThroughPlatform + 0.25f)
        {
            Physics2D.IgnoreLayerCollision(7, 12, false);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Physics2D.IgnoreLayerCollision(7, 12, true);
            goThroughPlatform = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform")) // Checks to see if the player is on a moving platform, making the player move with the platform as a result
        {
            transform.parent = other.transform;
        }

        if (other.gameObject.CompareTag("spikes") && Time.time >= lastHit + 2f) // Reset's the player's position upon coming into contact with spikes
        {
            isHit = true;
            lastHit = Time.time;
            fixedVelocity = true;
            freeze = true;
        }
        if (other.gameObject.CompareTag("enemy") && Time.time >= lastHit + 2f && enemyHit == false) // Throws the player back upon colliding with 
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = lastGravity;
            rb.constraints = RigidbodyConstraints2D.None;

            if (transform.position.x > other.transform.position.x)
            {
                rb.AddForce(new Vector2(400, 400));
            }
            else
            {
                rb.AddForce(new Vector2(-400, 400));
            }

            fixedVelocity = true;
            lastHit = Time.time;
            enemyHit = true;
            Physics2D.IgnoreLayerCollision(7, 8, true);
            dash = 0f;

            if (GetComponent<PlayerHealth>().health <= 0)
            {
                isHit = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spikes") && rb.velocity.y > 0f || rb.velocity.y < 0f)
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
                GetComponent<Weapon>().weaponUnlocked = true;
                GetComponent<Weapon>().canAttack = true;
            }
            if (other.gameObject.name == "DashObtainer")
            {
                dashUnlocked = true;
                canDash = true;
            }
            other.gameObject.GetComponent<ItemDisappear>().isTriggered = true;
        }

        if (other.gameObject.CompareTag("secret"))
        {
            other.gameObject.GetComponent<SecretActivator>().isTriggered = true;
        }

        if (other.gameObject.CompareTag("checkpoint"))
        {
            SceneManager.LoadScene("End Screen", LoadSceneMode.Single);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null;
    }
}