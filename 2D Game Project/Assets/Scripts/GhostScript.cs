using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public Transform player;
    private PlayerController pc;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        pc = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float speed = pc.Sanity/200;
        if (transform.position.x > player.position.x)
        {
            transform.position = transform.position + new Vector3(-0.01f * speed, 0, 0);
        }
        if (transform.position.x < player.position.x)
        {
            transform.position = transform.position + new Vector3(0.01f * speed, 0, 0);
        }
        if (transform.position.y > player.position.y)
        {
            transform.position = transform.position + new Vector3(0, -0.01f * speed, 0);
        }
        if (transform.position.y < player.position.y)
        {
            transform.position = transform.position + new Vector3(0, 0.01f * speed, 0);
        }
        if (pc.Sanity == 0)
        {
            Destroy(gameObject);
        }
        if (gameManager.deads1 == true)
        {
            Destroy(gameObject);
            gameManager.deads1 = false;
         }
    }
}
