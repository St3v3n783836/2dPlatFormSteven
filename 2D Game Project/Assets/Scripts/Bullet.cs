using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dead());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    { 
        Destroy(gameObject);
    }
    private IEnumerator dead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
