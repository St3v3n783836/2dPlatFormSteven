using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private PlayerController pc;
    private GameManager gm;
    private Animator Anim;
    private bool movement;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        gm = FindObjectOfType<GameManager>();
        Anim = GetComponent<Animator>();
        movement = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement == false)
        {
            StartCoroutine(floating());
            movement = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.CompareTag("Cherry"))
        {
            pc.Sanity = 0;
            gm.Cherrynum = 0;
            StartCoroutine(Collected());
        }
        if (other.CompareTag("Player") && this.CompareTag("WinCherry"))
        {
            pc.Sanity = 0;
            gm.WinCherrynum = 0;
            Destroy(gameObject);
        }
    }
    private IEnumerator Collected()
    {
        Anim.SetTrigger("Collect");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    private IEnumerator floating()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.up * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.up * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.up * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.up * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.up * Time.deltaTime * 0.5f);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector2.down * Time.deltaTime * 0.5f);
        yield return new WaitForSeconds(0.1f);
        movement = false;
    }
}
