using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public GameObject thing;
    public float good = 0;
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
    public float CheckPoint = 1;
    public bool deads;
    private lives lives;
    public float Lives;

    private Animator Anim;
    private Rigidbody2D _playerRb;
    private Collider2D playerCollider;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        PlayerHealth = 100;
        gameManager = FindObjectOfType<GameManager>();
        lives = FindObjectOfType<lives>();
        lightDone = true;
        good = 0;
    }

    // Update is called once per frame
    void Update()
    {
        run();
        jump();
        FlipSprite();
        dead();
        fall();
        started();
        Lives = lives.globalLives;
    }

    void started()
    {
        if (good == 1)
        {
            thing.SetActive(false);
        }
    }
    void run()
    {
        if (PlayerHealth > 0 && good == 1)
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
        if (Input.GetButtonDown("Jump") && PlayerHealth > 0 && good == 1)
            if (isOnGround == true)
            {
                {
                    _playerRb.velocity = new Vector2(_playerRb.velocity.x, jumpForce);
                }
            }
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_playerRb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRb.velocity.x) * 4.9496f, 4.9496f);
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
        }
    }
    void dead()
    {
        if (PlayerHealth == 0 && lightDone == true)
        {
            StartCoroutine(dead1());
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

        transform.position = new Vector3(-6, -0.8f, 0);
        _playerRb.velocity = new Vector3(0, 0, 0);
        Camera.transform.position = new Vector3(-6, -0.8f, 0);
        deads = true;
        if (lives.globalLives < 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (lives.globalLives > 0)
        {
            lives.globalLives = lives.globalLives - 1;
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
}
