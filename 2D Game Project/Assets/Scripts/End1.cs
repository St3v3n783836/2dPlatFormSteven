using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End1 : MonoBehaviour
{
    public GameObject Light1;
    public bool lightDone = true;
    public Transform Light;
    // Start is called before the first frame update
    void Start()
    {
        lightDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && lightDone == true)
        {
            StartCoroutine(Next());
        }
    }
    private IEnumerator Next()
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
        SceneManager.LoadScene(1);
    }
}
