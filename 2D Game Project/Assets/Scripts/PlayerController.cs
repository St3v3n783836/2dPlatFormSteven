using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public bool isOnGround;
    public Transform Camera;
    public Transform Light;
    public int PlayerHealth = 100;
    private GameManager gameManager;
    public GameObject Light1;
    public GameObject Camera1;
    public bool lightDone = true;
    public float Sanity = 0;
    public float CheckPoint = 1;
    public bool deads;
    public float Lives;
    private lives2 lives2;
    public float deaths;
    public float jumps;

    private Animator Anim;
    private Rigidbody2D _playerRb;
    private Collider2D playerCollider;

    public GameObject Insane;
    public GameObject InsaneSpikes;
    public GameObject InsaneBackground;
    public GameObject Sane;
    public GameObject SaneSpikes;
    
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        PlayerHealth = 100;
        gameManager = FindObjectOfType<GameManager>();
        lightDone = true;
        Camera1.GetComponent<OldCinemaEffect>().enabled = false;
        Sanity = 0;
        StartCoroutine(Started());
        lives2 = FindObjectOfType<lives2>();
        Lives = lives2.globalLives;
        deaths = 0;
        jumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSanity();
        run();
        jump();
        FlipSprite();
        dead();
        fall();
        Check_Point();
    }
    void run()
    {
        if (PlayerHealth > 0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _playerRb.velocity = new Vector2(horizontalInput * moveSpeed, _playerRb.velocity.y);

            if (Mathf.Abs(horizontalInput) > 0.1f)
            {
                Anim.SetFloat("MoveSpeed", Mathf.Abs(horizontalInput));
            }
            else
            {
                Anim.SetFloat("MoveSpeed", 0f);
            }
        }
    }
    void jump()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && PlayerHealth > 0)
        {
            isOnGround = true;
            Anim.SetBool("IsOnGround", true);
        }
        else
        {
            isOnGround = false;
            Anim.SetBool("IsOnGround", false);
        }
        if (Input.GetButtonDown("Jump") && PlayerHealth > 0)
            if (isOnGround == true)
            {
                {
                    _playerRb.velocity = new Vector2(_playerRb.velocity.x, jumpForce);
                    jumps = jumps + 1;
                }
            }
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRb.velocity.x) * 4.868194f, 4.942f);
        }
    }
    void fall()
    {
        float playerY = transform.position.y;
        if (playerY < -80) 
        {
            PlayerHealth = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Anim.SetTrigger("Player Hit");

            PlayerHealth = 0;
        } else if (other.gameObject.CompareTag("Enemy1"))
        {
            Lives = Lives - 5;
            Anim.SetTrigger("Player Hit");

            PlayerHealth = 0;
        }
    }
    void Check_Point()
    {
        if (CheckPoint < 2)
        {
            if (transform.position.x > 140)
            {
                CheckPoint = 2;
            }
        }
        if (CheckPoint < 3)
        {
            if (transform.position.x > 262)
            {
                CheckPoint = 3;
            }
        }
        if (CheckPoint < 4)
        {
            if (transform.position.x > 475)
            {
                CheckPoint = 4;
            }
            
        }
        if (CheckPoint < 5)
        {
            if (transform.position.y > 196)
            {
                CheckPoint = 5;
            }
        }
    }
    void dead()
    {
        if(PlayerHealth == 0 && lightDone==true)
        {
            StartCoroutine(dead1());
        }

    }

    void PlayerSanity()
    {
        if (Sanity > 0)
        {
            Insane.SetActive(true);
            InsaneBackground.SetActive(true);
            InsaneSpikes.SetActive(true);
            Sane.SetActive(false);
            SaneSpikes.SetActive(false);
            Camera1.GetComponent<OldCinemaEffect>().enabled = true;
            Camera1.GetComponent<OldCinemaEffect>().VignetteStrange = 2 * Sanity;
            Camera1.GetComponent<OldCinemaEffect>().GrainStrange = 0.01f * Sanity;
        }
        else
        {
            Camera1.GetComponent<OldCinemaEffect>().enabled = false;
            Insane.SetActive(false);
            InsaneBackground.SetActive(false);
            InsaneSpikes.SetActive(false);
            Sane.SetActive(true);
            SaneSpikes.SetActive(true);
        }
        if (Sanity > 45)
        {
            Sanity = 45;
                
        }
    }

    private IEnumerator dead1()
    {
        Light1.gameObject.SetActive(true);
        lightDone = false;
        Vector3 local = Light.transform.localScale;
        Light.transform.localScale = new Vector3(0.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(4.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(4.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(5.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(5.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(7.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(7.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(8.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(8.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(9.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(9.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(10.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);

        transform.position = new Vector3(42, 50, 0);
        _playerRb.velocity = new Vector3(0, 0, 0);
        Camera.transform.position = new Vector3(62, 75, 0);
        deads = true;
        deaths = deaths + 1;
        if (Lives < 1)
        {
            if (CheckPoint == 5)
            {
                Sanity = Sanity + 45;
                Lives = Lives - 1;
            }
            else
            {
                Sanity = Sanity + 10;
                Lives = Lives - 1;
            }
        } else if(Lives > 0)
        {
            Lives = Lives - 1;
        }

        Light.transform.localScale = new Vector3(9.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(9.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(8.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(8.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(7.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(7.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(5.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(5.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(4.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(4.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(0.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(0.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        PlayerHealth = 100;
        Light1.gameObject.SetActive(false);
        lightDone = true;
    }

    private IEnumerator Started()
    {
        Light1.gameObject.SetActive(true);
        Light.transform.localScale = new Vector3(9.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(9.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(8.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(8.01f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(7.51f, 10, 0);
        yield return new WaitForSeconds(0.0125f);
        Light.transform.localScale = new Vector3(7.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(6.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(5.51f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(5.01f, 10, 0);
        yield return new WaitForSeconds(0.025f);
        Light.transform.localScale = new Vector3(4.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(4.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(3.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(2.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(1.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(0.51f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light.transform.localScale = new Vector3(0.01f, 10, 0);
        yield return new WaitForSeconds(0.05f);
        Light1.gameObject.SetActive(false);

    }
}
