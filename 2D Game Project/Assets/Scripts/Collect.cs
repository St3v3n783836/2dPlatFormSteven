using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.CompareTag("Cherry"))
        {
            StartCoroutine(Collected());
        }
    }
    private IEnumerator Collected()
    {
        Anim.SetTrigger("Collect");
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
